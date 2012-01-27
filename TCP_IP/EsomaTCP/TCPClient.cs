using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Collections;

namespace EsomaTCP.TCPClient
{
	public delegate void DataManager(string data);
	
	public class TCPClient : IDisposable
	{
		private int _serverPort= 10000;
		private string _serverIPAddress;
		private string _userName="UNITY";
		private const int READ_BUFFER_SIZE = 4096;
		private byte[] _readBuffer = new byte[READ_BUFFER_SIZE];
		public string _message=string.Empty;
		private bool _disposed=false;
		private TcpClient _client = null;
		
		public event DataManager DataManager;
		
		//TODO: Replace with actual message size
	
		
		public TCPClient (string serverIPAddress, int serverPort)
		{
			_serverIPAddress = serverIPAddress;
			_serverPort = serverPort;
		}
		
		private TcpClient _tcpClientConnection
		{
			get
			{
				if (_client == null || !_client.Connected)
				{
					Connect();
				}
				
				return _client;
			}
		}
		
		public string ServerIP
		{
			get { return _serverIPAddress; }
			set { _serverIPAddress = value; }
		}
		
		public int ServerPort
		{
			get { return _serverPort; }
			set { _serverPort = value; }
		}
	
		public string UserName
		{
			get { return _userName; }
			set { _userName = value; }
		}
		
		public bool IsConnected
		{
			get { return (_client != null && _client.Connected); }
		}
		
		public void Connect()
		{
			try
			{
				if (String.IsNullOrEmpty(_serverIPAddress) ||
				    _serverPort < 0)
					throw new Exception("Connection requires a specified IP address and Port");
				_client = new TcpClient(_serverIPAddress, _serverPort);
				// Start an asynchronous read invoking DoRead to avoid lagging the user
	            // interface.
	            _client.GetStream().BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
				
				AttemptLogin(_userName);
	
			}
			catch (Exception ex)
			{
				//"Server is not active.  Please start server and try again.      " + ex.ToString();
			}
		}
			
		private void AttemptLogin(string user)
	    {
	        SendData("CONNECT|"+ user);
	    }
	
		public void CloseConnection()
		{
			if (_client.Connected)
			{
				SendData("DISCONNECT|"+UserName);
				_client.Close();
			}
		}
		
		
		private void DoRead(IAsyncResult ar)
	    { 
			NetworkStream stream = _client.GetStream();
	        
			int bytesRead;

			try 
	        {
	            // Ensure that no other threads try to use the stream at the same time.
	            lock (stream)
	            {
					// Finish asynchronous read into readBuffer and get number of bytes read.
	                bytesRead = stream.EndRead(ar);
				}
					
	            _message += Encoding.ASCII.GetString(_readBuffer, 0, bytesRead);

				// Check for EOF or an empty message.
		        if (stream.DataAvailable)
		        {
		            // We are not finished reading.
		            // Asynchronously read more message data from  the server.
					lock (stream)
					{
		            	stream.BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
					}
		        } 
		        else
		        {
					DataManager(_message.Substring(0, _message.Length - 1));
					_message = string.Empty;

					lock (stream)
		            {
		                // Start a new asynchronous read into readBuffer.
		                stream.BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
		            }
		        }
	        } 
	        catch( Exception e){
	        }
	    }
		
		public bool SendData(string data)
		{
			bool success = false;
			data=data + (char) 13;
			//byte[] convertedData = System.Text.Encoding.ASCII.GetBytes(data);
			try
			{
				StreamWriter writer = new StreamWriter(_client.GetStream());
	            writer.Write(data);
	            writer.Flush();
			}
			catch(Exception ex)
			{
				//TODO: Log error
			}
			
			return success;
		}
		
		#region IDisposable Implementation
		
		public void Dispose()
		{
			Dispose(true);
			
			// This object will be cleaned up by the Dispose method.
	        // Therefore, you should call GC.SupressFinalize to
	        // take this object off the finalization queue
	        // and prevent finalization code for this object
	        // from executing a second time.
	        GC.SuppressFinalize(this);
		}
		
		// Dispose(bool disposing) executes in two distinct scenarios.
	    // If disposing equals true, the method has been called directly
	    // or indirectly by a user's code. Managed and unmanaged resources
	    // can be disposed.
	    // If disposing equals false, the method has been called by the
	    // runtime from inside the finalizer and you should not reference
	    // other objects. Only unmanaged resources can be disposed.
	    private void Dispose(bool disposing)
	    {
	        // Check to see if Dispose has already been called.
	        if(!_disposed)
	        {
	            // If disposing equals true, dispose all managed
	            // and unmanaged resources.
	            if(disposing)
	            {
	                // Dispose managed resources.
					if (_client != null)
					{
						if (_client.Connected)
	                    	_client.Close();
						
						_client = null;
					}
	            }
	
	            // Note disposing has been done.
	            _disposed = true;
	
	        }
	    }
	
	    // Use C# destructor syntax for finalization code.
	    // This destructor will run only if the Dispose method
	    // does not get called.
	    // It gives your base class the opportunity to finalize.
	    // Do not provide destructors in types derived from this class.
	    ~TCPClient()
	    {
	        // Do not re-create Dispose clean-up code here.
	        // Calling Dispose(false) is optimal in terms of
	        // readability and maintainability.
	        Dispose(false);
	    }
		
		#endregion
	}
	
}