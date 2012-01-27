using System;
using System.IO.Ports;

namespace pulsoximeter
{

	public class OnyxII
	{


		private int boudRate = 9600;
		private string portName = "COM18";
		private bool simulate = false;
		private SerialPort btComPort;
		private int heartRate = 0;
		private int saturation = 0;
		private string hrSat = "0, 0";		//the heartrate and the oxigensaturation are transmitted in a string seperated through a comma
		private int randHr = 0;
		private int randSat = 0;
		
		System.Threading.Thread readComThread;

		public OnyxII(bool sim)
		{
			init (sim);
		}
		//currently the code is written just for Serial Data Format #8

		public static void Main (string[] args)
		{
			OnyxII obj = new OnyxII(false);

			bool retval;

			if (args.Length > 0 && args[0] == "sim")
				retval = obj.init (true);
			else
				retval = obj.init (false);

			if (!retval) {
				System.Console.WriteLine("Could not init device.\n");
				return;
			}
			


//			if (obj.OpenPort()==true)
//			{
//
//			obj.SetDataFormat8();
//				int i;
//				System.Console.WriteLine("Press escape to stop the program.");
//				while(obj.readKeyboard() && obj.IsOpen ()){
//						i= obj.StartGettingTheValuesOutOfSerialDataFormat8;
//						Console.Write( i + "\n");
//				}
//			}
		}

		public string GetHrAndSpo2 ()
		{
			if (simulate){
//				System.Threading.Thread.Sleep(1000);
				Random random = new Random();
				randHr = (int) random.Next(60,70);
				randSat = (int) random.Next(90,99);
				return randHr.ToString() + ", " + randSat.ToString();
			}

			else
			{
				if(ConnectedToDevice())
				{
					hrSat = heartRate.ToString() + "," + saturation.ToString();
					return hrSat;
				}
				else
				{
					return("Connection not open!\n");
				}
			}
		}

		public bool OpenConnection()
		{
			if (simulate) {
 				return true;
			}

			try
			{
				if (btComPort.IsOpen == true) btComPort.Close();
				btComPort.BaudRate = boudRate;
				btComPort.PortName = portName;
				btComPort.Open();
				Console.Write("Port opened!\n");
				System.Threading.Thread.Sleep(500);
				readComThread = new System.Threading.Thread (StartGettingTheValuesOutOfSerialDataFormat8);
				readComThread.Start();
				Console.Write("Thread started!\n");
				return true;
			}
			
			catch (Exception ex)
			{
				Console.Write("Problem at opening the connection or starting the readComThread!\n", ex.Message);
				try 
				{
					readComThread.Abort();
					Console.Write("Thread was Aborted!\n");
				}
				catch (Exception ex2)
				{
					Console.Write("Thread has not been open!\n", ex2.Message);
				}
				return false;
			}
		}

		public bool CloseConnection()
		{
			try
			{
				btComPort.Close();
				readComThread.Abort();
				return true;
			}
			catch (Exception ex)
			{
				Console.Write("Problem at closing the connection!\n", ex.Message);
				return false;
			}
		}

		public bool init(bool simulated){
			if (simulated){
				simulate = true;
				System.Console.WriteLine("In simulation mode.\n");
			} else {
				simulate = false;
				btComPort = new SerialPort();
			}

			return OpenConnection();
		}

		public bool readKeyboard()
		{
			if (Console.KeyAvailable)
				if (Console.ReadKey(true).Key == ConsoleKey.Escape)
					return false;

			return true;
		}

        //listens to the COM Port and stores the values to
		private void StartGettingTheValuesOutOfSerialDataFormat8()
		{

			int incomingByte =0;
			int tempHeartRate = 0;

			while (btComPort.IsOpen)
			{
				incomingByte = btComPort.ReadByte();
				if (incomingByte > 127)									//Byte 1 - Status gets ignored
				{
					incomingByte = incomingByte & 3;					//the last two bit of the 1st Byte (Status) are HR7 and HR8 the rest can be ignored
					tempHeartRate = btComPort.ReadByte(); 				//Byte 2 - is the Heart Rate Data HR0 - HR6
					heartRate = tempHeartRate | (incomingByte << 7);	//now the HeartRate also includes the msb
					saturation = btComPort.ReadByte();
					btComPort.ReadByte();								//the last Byte will be ignored again
					//Console.Write(heartRate.ToString() + "," + saturation.ToString() + "\n");
				}
			}
		}

		private void SetDataFormat8() 	//just for giving an idea how to transmit data to the device
		{
			if (!(btComPort.IsOpen ==true))
			{
				btComPort.Open();
			}
			btComPort.ReadByte();

			string msg = "0x02,0x70,0x02,0x02,0x08,0x03"; // or \X02...

			btComPort.Write(msg);



		}
		private void WriteData (string msg)
		{
			if (!(btComPort.IsOpen ==true))
			{
				btComPort.Open();
			}


			btComPort.Write(msg);

			Console.WriteLine(msg + " was written to the COM Port!\n");

		}

		public bool ConnectedToDevice()
		{
			if (simulate)
				return true;
			else
				return btComPort.IsOpen;
		}
	}
}
