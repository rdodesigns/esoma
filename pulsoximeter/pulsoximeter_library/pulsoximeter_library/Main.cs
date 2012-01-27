using System;
using System.IO.Ports;

namespace pulsoximeter
{
	//*************************************//
	//****     OnyxII(int port)     *******//
	// port> 0 for setting the Bluetooth ComPort
	// port= 0 for simulation mode
	// port= -1 for demonstration mode
	//   demonstration is started with openConnection it raises from 105 to 155 and decreases to 130 again
	//*************************************//
	public class OnyxII
	{


		private int boudRate = 9600;
		//private string portName = "COM18";
		private string portName = "/dev/tty.Nonin_Medical_Inc_745654";
		private bool simulate = false;
		private static bool demonstrate = false;
		private SerialPort btComPort;
		private int heartRate = 0;
		private int saturation = 0;
		private string hrSat = "0, 0";		//the heartrate and the oxigensaturation are transmitted in a string seperated through a comma
		private int randHr = 0;
		private int randSat = 0;
		
		System.Threading.Thread readComThread;

		// This constructor is for creating a connection to the OnyxII Pulsoxymeter from Nonin
		// The port is the COM Port number of the device connected via Bluetooth
		// 		- for Simulation Mode 0 has to be entered 
		// 		- for Demonstration Mode -1 has to be entered 
		public OnyxII(int port)
		{
			if (port<=0)							//simulation mode
			{
				if (port==-1) demonstrate=true;		//demonstration mode
					init (true);
			}
			else
			{
				portName = "COM" + port.ToString();
				init (false);
			}
		}

		public static void Main (string[] args)
		{
			OnyxII obj = new OnyxII(-1);
			obj.OpenConnection();
		}

		// opens the connection to the OnyxII and returns true if succeeded 
		public bool OpenConnection()
		{
			if (simulate) {
				if(demonstrate) 
				{
					readComThread = new System.Threading.Thread (StartGettingTheValuesOutOfSerialDataFormat8);
					readComThread.Start();
				}
 				return true;
			}

			try
			{
				if (btComPort.IsOpen == true) 
				{
					Console.Write("The connection is already open!\n");
					return false;
				}
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
				}
				return false;
			}
		}
		
		
		// Returns the current HeartRate and SpO2 value seperated by ,
		public string GetHrAndSpo2 ()
		{
			if (simulate){
				
				if (demonstrate)	//demonstration mode (values get set in StartGettingTheValuesOutOfSerialDataFormat8
				{
					hrSat= heartRate.ToString() + "," + saturation.ToString();
					return hrSat;
				}
				else
				{
					Random random = new Random();
					randHr = (int) random.Next(60,70);
					randSat = (int) random.Next(90,99);
					hrSat = randHr.ToString() + ", " + randSat.ToString();
					return hrSat;
				}
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

		
		// Closes the connection to the OnyxII
		// returns true if succeeded
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
		
		
		private bool init(bool simulated){
			if (simulated){
				simulate = true;
				System.Console.WriteLine("In simulation mode.\n");
				return true;
			} else {
				simulate = false;
				btComPort = new SerialPort();
				return true;
			}
		}

		private bool readKeyboard()
		{
			if (Console.KeyAvailable)
				if (Console.ReadKey(true).Key == ConsoleKey.Escape)
					return false;

			return true;
		}

        //listens to the COM Port and stores the values to HeartRate and saturation
		private void StartGettingTheValuesOutOfSerialDataFormat8()
		{
			if (simulate && demonstrate)
			{
				System.Threading.Thread.Sleep(500);
				
				Random r = new Random();
				
				do
				{
					for (int i=0; i<=18; i++)
					{
						if (i>=10) 
						{
							heartRate=195-(5*i);
						}
						else
						{
							heartRate = 105 + 5*i;
						}
						saturation= r.Next(93,95);
						//Console.Write(heartRate.ToString() + "\n");
						System.Threading.Thread.Sleep(1000);
					}	
										
				}
				while(ConnectedToDevice());
				
				readComThread.Abort();
				
			}
			else
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
				readComThread.Abort();
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
		
		//returns true if a connection is open
		public bool ConnectedToDevice()
		{
			if (simulate)
				return true;
			else
				return btComPort.IsOpen;
		}
	}
}
