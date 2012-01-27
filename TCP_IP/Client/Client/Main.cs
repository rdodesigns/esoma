using System;
using EsomaTCP.TCPClient;

class MainClass
{
	public static TCPClient cli;
	public static bool _exit= false;
	public static void Main (string[] args)
	{
		cli=new TCPClient("127.0.0.1",10000);
		cli.UserName="UNITY";
		cli.DataManager+= new DataManager(MainClass.OnDataReceived);
		cli.Connect();
		do{
			
		}while(!_exit);
		cli.CloseConnection();
	}
	static public void OnDataReceived(string data)
    {
		if(data=="REFUSE"){
			_exit=true;
		}
		else{
			System.Console.WriteLine(data);
			cli.SendData("D|U|OK");
			_exit=true;
			
		}
    }
}

