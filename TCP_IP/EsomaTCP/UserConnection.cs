using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace EsomaTCP.TCPServer
{
	public delegate void LineReceive(UserConnection sender, string Data);
	
	// The UserConnection class encapsulates the functionality of a TcpClient connection
	// with streaming for a single user.
	
	public class UserConnection
	{
	    private const int READ_BUFFER_SIZE = 4096;
	
	    private byte[] _readBuffer = new byte[READ_BUFFER_SIZE];
		private string _message = string.Empty;
	
		private TcpClient _client;
	    public event LineReceive LineReceived;
	
		//public TcpClient Client { get { return _client; } set { _client = value; } }
		public string Name { get; set; }
		
		public UserConnection(TcpClient client)
	    {
	        _client = client;
	        // This starts the asynchronous read thread.  The data will be saved into
	        // readBuffer.
	        _client.GetStream().BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(StreamReceiver), null);
	    }
	
	
	    // This subroutine uses a StreamWriter to send a message to the user.
	    public void SendData(string Data)
	    {
	        //lock ensure that no other threads try to use the stream at the same time.
	        lock (_client.GetStream())
	        {
	            StreamWriter writer = new StreamWriter(_client.GetStream());
	            writer.Write(Data + (char) 13 + (char) 10);
	            // Make sure all data is sent now.
	            writer.Flush();
	        }
	    }
	    // This is the callback function for TcpClient.GetStream.Begin. It begins an 
	    // asynchronous read from a stream.
	    private void StreamReceiver(IAsyncResult ar)
	    {
			NetworkStream stream = _client.GetStream();
	        
			int bytesRead;
	        //string strMessage="";
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
		            	stream.BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(StreamReceiver), null);
					}
		        } 
		        else
		        {
					LineReceived(this, _message.Substring(0, _message.Length - 1));
					_message = string.Empty;

					lock (stream)
		            {
		                // Start a new asynchronous read into readBuffer.
		                stream.BeginRead(_readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(StreamReceiver), null);
		            }
		        }
					
	            // Convert the byte array the message was saved into, minus one for the
	            // Chr(13).
	            //LineReceived(this, strMessage);
	            // Ensure that no other threads try to use the stream at the same time.
	        } 
	        catch( Exception e){
	        }
	    }
			
		/*
		private void StreamReceiver(IAsyncResult ar)
	    {
			
	        int BytesRead;
	        string strMessage;
	        try 
	        {
	            // Ensure that no other threads try to use the stream at the same time.
	            lock (client.GetStream())
	            {
					// Finish asynchronous read into readBuffer and get number of bytes read.
	                BytesRead = client.GetStream().EndRead(ar);
	            }
	            // Convert the byte array the message was saved into, minus one for the
	            // Chr(13).
	            strMessage = Encoding.ASCII.GetString(readBuffer, 0, BytesRead - 1);
				
	            LineReceived(this, strMessage);
	            // Ensure that no other threads try to use the stream at the same time.
	            lock (client.GetStream())
	            {
	                // Start a new asynchronous read into readBuffer.
	                client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(StreamReceiver), null);
	            }
	        } 
	        catch( Exception e){
	        }
	    }*/
	}

}