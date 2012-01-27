using System;
using pulsoximeter;


namespace TestDLL
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			OnyxII po = new OnyxII(18);
			
		//	Console.Write(po.GetHrAndSpo2() + "\n");
			
			po.OpenConnection();
			
			while (true)
			{
				Console.Write(po.GetHrAndSpo2() + "\n");
				System.Threading.Thread.Sleep(1000);
			
			}
		}
	}
}
