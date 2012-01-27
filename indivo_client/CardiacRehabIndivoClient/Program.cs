using System;
using System.Collections.Generic;
using EsomaTCP.TCPClient;
using EsomaTCP;
using EsomaSharedDocuments;
using System.Configuration;

namespace CardiacRehabIndivoClient
{
	public class Program
	{
		private const string CONNECT_NAME = "INDIVO";
		private const string APP_NAME = "I";
		private const string IP_KEY = "hostIp";
		private const string PORT_KEY = "hostPort";
		private const string TESTMODE_KEY = "testMode";

		/*
		private static bool _isConnected = false;
		private static bool _isReceiving = false;
		private static DateTime _lastReceived = DateTime.MinValue;
		*/
		
		private static bool _continue = true;
		private static List<string> _data = new List<string>();
		private static TCPClient _client = null;

			
		static void Main (string[] args)
		{
			string serverIp = "localhost";
			int serverPort = 10000;
			bool testMode = false;
			
			if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings[IP_KEY]))
				serverIp = ConfigurationManager.AppSettings[IP_KEY];

			if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings[PORT_KEY]))
				serverPort = Int32.Parse(ConfigurationManager.AppSettings[PORT_KEY]);
			
			if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings[TESTMODE_KEY]))
				testMode = bool.Parse(ConfigurationManager.AppSettings[TESTMODE_KEY]);
			
			if (!testMode)
			{
				using (_client = new TCPClient(serverIp, serverPort))
				{
					_client.UserName = CONNECT_NAME;
					_client.DataManager += HandleClientDataManager;
					_client.Connect();
	
					while (_continue)
					{
						/*
						if (_isConnected && _isReceiving && (_lastReceived - DateTime.Now).Seconds > 5)
						{
							_isReceiving = false;
							_lastReceived = DateTime.MinValue;
						}
						*/
					}
				}
			}
			else // run testing code
			{
				DataRequestor dr = new DataRequestor();
				IndivoInitialization init = new IndivoInitialization("rpoole", "rpoole-dope75");
				
				string accountId = dr.Login(init.UserName, init.Password);
				ExercisePlan exPlan = dr.GetExercisePlan(accountId);
				Demographics demo = dr.GetDemographics(accountId);
				IndivoExercisePlan plan = CreateIndivoExercisePlan(accountId, exPlan, demo);
				Console.WriteLine(plan.Plan.exerciseGroups.Count);
				plan = plan.GetTodaysExercisePlan();
				Console.WriteLine(plan.Plan.exerciseGroups.Count);
			}
			
			return;
		}
		
		static void HandleClientDataManager (string data)
		{
			Console.WriteLine(data);

			string command = data;
			string[] dataArray = null;
			
			if (data.Contains("|"))
			{
				dataArray = data.Split(new char[] { '|' });
				command = dataArray[0];
			}
			
			switch (command)
			{
				case SharedConstants.INITIALIZE:
					InitializeIndivo(dataArray);
					break;
				case SharedConstants.END_SESSION:
					Console.WriteLine("Closing session");
					_client.CloseConnection();
					_continue = false;
					break;
				default:
					//_isReceiving = true;
					//_lastReceived = DateTime.Now;
					_data.Add(data);
					break;
			}

			if (command == EConnectionResponse.ConnectionAccepted.ToString())
			{
				Console.WriteLine("Connected");
				//_isConnected = true;
			}
			else if (command == EConnectionResponse.ConnectionRefused.ToString())
			{
				Console.WriteLine("Disconnected");
				//_isConnected = false;
				_continue = false;
			}
		}
		
		private static void InitializeIndivo(string[] dataArray)
		{
			Console.WriteLine("Initializing");
			
			if (dataArray.Length > 1)
			{
				string jsonString = dataArray[1];
				Console.WriteLine(jsonString);
				IndivoInitialization init = new IndivoInitialization(jsonString);

				Console.WriteLine("Getting init data from indivo using username: " + init.UserName + " and password: " + init.Password);
				
				DataRequestor dr = new DataRequestor();
				string accountId = dr.Login(init.UserName, init.Password);
				Demographics demo = dr.GetDemographics(accountId);
				ExercisePlan exPlan = dr.GetExercisePlan(accountId);
				IndivoExercisePlan plan = CreateIndivoExercisePlan(accountId, exPlan, demo);
				//plan = plan.GetTodaysExercisePlan();
				
				SendExercisePlan(plan);
			}
			else //no data from server
			{
				_continue = false;
			}
		}
		
		private static IndivoExercisePlan CreateIndivoExercisePlan(string accountId, ExercisePlan plan, Demographics demo)
		{
			// Default values in case we can't retrieve demographics
			int age = 0;
			string gender = string.Empty;
			
			if (demo != null)
			{
				age = GetAgeFromBirthDate(demo.dateOfBirth);
				gender = demo.gender;
				
				// dummy data in case indivo cant connect
				if (String.IsNullOrEmpty(gender))
					gender = "Female";
			}
			
			IndivoExercisePlan indivoPlan = new IndivoExercisePlan(plan, accountId, age, gender);
			return indivoPlan;
		}
		
		private static void SendExercisePlan(IndivoExercisePlan plan)
		{
			Console.WriteLine(plan.ToString());
			string sentData = string.Format("I|I|{0}", plan.ToString());
			_client.SendData(sentData);
		}
		
		private static int GetAgeFromBirthDate(DateTime birthDate)
		{
			// dummy up data if its not returned from Indivo
			if (birthDate == default(DateTime))
				return 57;
			
			int age = (DateTime.Today.Year - birthDate.Year);
			if (birthDate > DateTime.Today.AddYears(-age))
				age--;
			
			Console.WriteLine(age);
			return age;
		}
	}
}

