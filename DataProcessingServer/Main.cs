using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using EsomaTCP;
using EsomaTCP.TCPServer;
using EsomaSharedDocuments;
using IndivoClient;
using System.Configuration;


class MainClass
{
	public static EsomaSharedDocuments.IndivoInitialization _indivoInit;
	public static EsomaSharedDocuments.IndivoExercisePlan _indivoPlan;
	public static EsomaSharedDocuments.IndivoExerciseResult _indivoResults;
	public static ExerciseResultExerciseGroupExercise ex;
	public static double exerciseAdherence = 0;
	public static List<int> allHRcalc;
	public static List<int> allOXcalc;
	public static List<double> allEAcalc;
	public static TCPServer serv;
	public static PulseOX pulse;
	public static int COMPort=-1;
	public static double[] HRtarget;
	public static long lastTrigger= 0;
	public static int secondsTrigger=10;
	public static int numrep=0;
	public static int File_targetHR=0;
	public static string sexercisePlan="";
	
	public static bool indivo_init=false;
	public static bool unity_init=false;
	public static bool exercise_finished=true;
	public static int cen=-1;
	
	public static bool exit=false;
	private static string lastmsg="GREAT";
	
	public static void Main (string[] args)
	{
		
		if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["COMport"]))
			COMPort = Int32.Parse(ConfigurationManager.AppSettings["COMport"]);

		if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["targetHR"]))
			File_targetHR = Int32.Parse(ConfigurationManager.AppSettings["targetHR"]);
		
		Console.WriteLine ("ESOMA Data Processing Server");
		allHRcalc=new List<int>();
		allOXcalc=new List<int>();
		allEAcalc=new List<double>();
		HRtarget=new double[2];
		StartPulseOX();
		StartServer();
	    do{ 
			if(!indivo_init){
				if(serv.IsClientConnected("INDIVO")){
					_indivoInit=new IndivoInitialization("rpoole","rpoole-dope75");
					Console.WriteLine("INITIALIZE INDIVO:" +_indivoInit.ToString());
					serv.SendToClient("INITIALIZE|"+_indivoInit.ToString()+"|","INDIVO");
					indivo_init=true;
				}
			}else if(serv.IsClientConnected("UNITY") && !unity_init && sexercisePlan!=""){
				unity_init=true;
				Console.WriteLine(sexercisePlan);
				_indivoPlan = new IndivoExercisePlan(sexercisePlan);
			//	Console.WriteLine("hola");
				SetHRtarget();
				_indivoResults = new IndivoExerciseResult(new ExerciseResult(),_indivoPlan.AccountID);
				_indivoResults.Result.exerciseGroups = new System.Collections.Generic.List<ExerciseResultExerciseGroup>();
				_indivoResults.Result.exerciseGroups.Add(new ExerciseResultExerciseGroup());
				_indivoResults.Result.exerciseGroups[0].exercises = new System.Collections.Generic.List<ExerciseResultExerciseGroupExercise>();
				ControlProgress();
			}
			if(!serv.IsClientConnected("UNITY")){
				unity_init=false;
				cen=-1;
			}
			
		}while(!exit);
		serv.SendToClient("ENDSESSION|"+_indivoResults.ToString()+"|","INDIVO");
		Console.WriteLine("ENDSESSION|"+_indivoResults.ToString()+"|");
		pulse.ClosePulseOX();
	}
	private static void ControlProgress(){
		
		Console.WriteLine(_indivoPlan.Plan.exerciseGroups[0].exercises.Count);
		
		if(cen!=-1){
			ex.repititions=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].repititions.maximumValue;
		//	ex.repititionsSpecified= _indivoPlan.Plan.exerciseGroups[0].exercises[cen].repititions.maximumValue;
			
			ex.activity.id=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].activity.id;
			ex.activity.name=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].activity.name;
			ex.activity.type=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].activity.type;
			
			ex.sets=0;
			ex.setsSpecified=false;
			ex.startTime=DateTime.Now;
			_indivoResults.Result.exerciseGroups[0].exercises.Add(ex);
		}

		if(cen<_indivoPlan.Plan.exerciseGroups[0].exercises.Count-1){
			cen++;
			Console.WriteLine("SENDING EXERCISE "+cen+" TO UNITY");
			string currentExercise=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].activity.id;
			string currentExerciseName=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].activity.name;
			int repetitions=_indivoPlan.Plan.exerciseGroups[0].exercises[cen].repititions.maximumValue;
			
			Console.WriteLine("Gender: "+_indivoPlan.Gender+" Doing exercice: "+currentExercise+" MIN HR: "+HRtarget[0]+" MAX HR: "+ HRtarget[1]);
			serv.SendToClient("I|"+_indivoPlan.Gender+"|"+currentExercise+"|"+currentExerciseName+"|"+repetitions+"|"+HRtarget[0]+"|"+HRtarget[1]+"|","UNITY");
			exercise_finished=false;
			ex= new ExerciseResultExerciseGroupExercise();

		}else{
			Console.WriteLine("SESSION FINISHED");
			exit=true;
		}
	}
	
	static public void OnDataReceived(string sendername, string data)
    {
		//Console.WriteLine("DPS Got Data: ");
		//Console.WriteLine(data);
		//Console.WriteLine();
		//data=data+"|";
		//	System.Console.WriteLine(sendername);
		string[] dataArray = data.Split(new char[] { '|' });
		//System.Console.WriteLine("INDIVO: "+data);
		if(sendername=="I"){
			switch(dataArray[1]){
				case "I":
			//	if(dataArray[2][dataArray[2].Length-1].Equals("}")){
					Console.WriteLine("DPS Split data is:");
					Console.WriteLine(dataArray[2]);
					sexercisePlan=dataArray[2];
					Console.WriteLine();
				//	Console.WriteLine("hola");
			//	}
				break;
			}
		}
		if(sendername=="U"){
			switch(dataArray[1]){
				case "C": // control
					Console.WriteLine("UNITY SAYS: EXERCISE FINISHED");
					ControlProgress();
				break;
				case "D": // DATA
					//Console.WriteLine(data);
					int patientLoc = data.IndexOf("P") + 2;
					int trainerLoc = data.IndexOf("T") + 2;
					string dataPatient = data.Substring(patientLoc, trainerLoc - patientLoc - 3);
					//Console.WriteLine(dataPatient);
					string dataTrainer = data.Substring(trainerLoc+1, data.Length - trainerLoc - 1);
					//Console.WriteLine(dataTrainer);
					ExerciseAdherence ea = new ExerciseAdherence();
					exerciseAdherence = ea.ProcessData(dataPatient, dataTrainer);
					//Console.WriteLine("ExAdh:" +exerciseAdherence);
				break;
				
			}
			
		}
    }
	static public void OnPulseReceived(int HR, int OX)
    {
		
		bool triggerActivated=false;
		string msg="";
			
		if(indivo_init){	
			
			if(File_targetHR!=0){
				HRtarget[1]=File_targetHR;
				HRtarget[0]=File_targetHR-20;
			}
			if(exerciseAdherence<4.5F){
				triggerActivated=true;
				msg="GREAT";
			}
			if(HR>HRtarget[1]){
				triggerActivated=true;
				msg="MAX";
			}
			if(OX<92){
				triggerActivated=true;
				msg="MAX";
			}
			int HRs=(int)(((HR-HRtarget[0])/(HRtarget[1]-HRtarget[0]))*100);
			if(triggerActivated && DateTime.Now.Ticks-lastTrigger > 100000*100*secondsTrigger || lastmsg!=msg){
				serv.SendToClient("T|"+msg+"|"+HR+"|"+OX+"|"+HRs+"|"+exerciseAdherence+"|","UNITY");	
				allHRcalc.Add(HR);
				allOXcalc.Add(OX);
				allEAcalc.Add(exerciseAdherence);
				lastTrigger= DateTime.Now.Ticks;
				lastmsg=msg;
			}else{
				serv.SendToClient("D|"+HR+"|"+OX+"|"+HRs+"|"+exerciseAdherence+"|","UNITY");
				Console.WriteLine(HR+"|"+OX+"|"+HRs+"|"+exerciseAdherence);
			}
		}
		
		
    }
	static private void SetHRtarget(){
		HRtarget=new double[2];
		int HRmax= 220-_indivoPlan.Age;
		HRtarget[0] = HRmax*0.70;
		HRtarget[1] = HRmax*0.85;
		System.Console.WriteLine("Target HR: ("+HRtarget[0].ToString()+" - "+HRtarget[1].ToString()+")");
	}
	static private void StartServer(){
		serv = new TCPServer();
		serv.DataManager+= new DataManager(MainClass.OnDataReceived);
		serv.StartServer();
		Console.WriteLine("TCP Server Started::Listening to port 10000");
	}
	
	static private void StartPulseOX(){
		
			pulse=new PulseOX();
			pulse.Port=3;
			pulse.PulseManager+=new PulseManager(MainClass.OnPulseReceived);
			pulse.StartPulseOX();
		
	}
}


