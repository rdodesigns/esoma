using System;
using pulsoximeter;
using System.Threading;


public delegate void PulseManager(int HR, int BOX);
public class PulseOX
{
	private OnyxII pulse;
	private int _port = -1; // simulation mode
	private Thread listenerThread;
	public event PulseManager PulseManager;
	
	public PulseOX(){
	}
	
	public void StartPulseOX()
	{
		pulse=new OnyxII(_port);
		pulse.OpenConnection();
		listenerThread = new Thread(new ThreadStart(DoListen));
    	listenerThread.Start();
		
	}
	public void ClosePulseOX(){
		pulse.CloseConnection();
	}
	public int Port
	{
	get { return _port; }
	set { _port = value; }
	}
	
	public void DoListen(){
		try{
		do{
			getInput();
			System.Threading.Thread.Sleep(1000);
		}while(true);
		}catch{
			pulse=new OnyxII(-1);
			pulse.OpenConnection();
			listenerThread = new Thread(new ThreadStart(DoListen));
	    	listenerThread.Start();
		}
	}
	
	public void getInput(){
		string str = pulse.GetHrAndSpo2();
		int[] vals = parseData(str);
		PulseManager(vals[0],vals[1]);
    }
	private int[] parseData(string str){
		string[] vals = str.Split(',');
		return new int[] {int.Parse(vals[0]), int.Parse(vals[1])};
    }
}


