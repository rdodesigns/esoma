using System;
using EsomaTCP.TCPServer;

class MainClass
{
	public static TCPServer serv;
	
	public static void Main (string[] args)
	{
		serv = new TCPServer();
		serv.DataManager+= new DataManager(MainClass.OnDataReceived);
		serv.StartServer();
		do{
			
		}while(true);
	}
	
	static public void OnDataReceived(string sendername, string data)
    {
		//System.Console.WriteLine(sendername);
		if(sendername=="I"){
			System.Console.WriteLine("indivo: "+data);
		}
		if(sendername=="U"){
			System.Console.WriteLine("unity: "+data);
		}
    }
}

