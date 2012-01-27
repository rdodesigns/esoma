using System;
namespace EsomaMessageParser
{
	public class MessageParser
	{
		#region Constants
		
		private const int INDIVO_USER_ID_LENGTH = 300;
		private const int INDIVO_USER_ID_OFFSET = 0;

		private const int EXERCISE_ID_LENGTH = 50;
		private const int EXERCISE_ID_OFFSET = 300;
		
		private const int COMMAND_LENGTH = 15;
		private const int COMMAND_OFFSET = 350;
		
		private const int MET_LENGTH = 4;
		private const int MET_OFFSET = 365;

		private const int HEART_RATE_LENGTH = 3;
		private const int HEART_RATE_OFFSET = 369;
	
		private const int BO_LEVEL_LENGTH = 2;
		private const int BO_LEVEL_OFFSET = 371;
		
		private const int JOINT_DATA_OFFSET = 373;

		#endregion
		
		#region Private Fields
		
		private static char[] _message;
		
		#endregion
		
		#region Constructors
		
		public MessageParser ()
		{
		}
		
		public MessageParser (char[] message)
		{
			_message = message;
		}
		
		public MessageParser (string message)
		{
			_message = message.ToCharArray();
		}
		
		#endregion
		
		#region Properties
		
		public char[] Message
		{
			get { return _message; }
			set { _message = value; }
		}
		
		public string MessageString
		{
			get { return _message.ToString(); }
			set { _message = value.ToCharArray(); }
		}
		
		public char[] IndivoUserID
		{
			get { return GetIndivoIdFromMessage(); }
		}
		
		public string IndivoUserIDString
		{
			get { return IndivoUserID.ToString(); }
		}
		
		public char[] ExerciseID
		{
			get { return GetExerciseIdFromMessage(); }
		}
		
		public string ExerciseIDString
		{
			get { return ExerciseID.ToString(); }
		}
		
		public char[] Command
		{
			get { return GetCommandFromMessage(); }
		}
		
		public string CommandString
		{
			get { return Command.ToString(); }
		}
		
		public char[] MET
		{
			get { return GetMETFromMessage(); }
		}
		
		public string METString
		{
			get { return MET.ToString(); }
		}
		
		public char[] HeartRate
		{
			get { return GetHeartRateFromMessage(); }
		}
		
		public string HeartRateString
		{
			get { return HeartRate.ToString(); }
		}
		
		public char[] BOLevel
		{
			get { return GetBOLevelFromMessage(); }
		}
		
		public string BOLevelString
		{
			get { return BOLevel.ToString(); }
		}
		
		public char[] JointData
		{
			get { return GetJointDataFromMessage(); }
		}
		
		public string JointDataString
		{
			get { return JointData.ToString(); }
		}
		
		#endregion
		
		#region Public Static Methods
		
		public static char[] GetIndivoIdFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(INDIVO_USER_ID_OFFSET, INDIVO_USER_ID_LENGTH);
		}
		
		public static char[] GetExerciseIdFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(EXERCISE_ID_OFFSET, EXERCISE_ID_LENGTH);
		}
		
		public static char[] GetCommandFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(COMMAND_OFFSET, COMMAND_LENGTH);
		}
		
		public static char[] GetMETFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(MET_OFFSET, MET_LENGTH);
		}
		
		public static char[] GetHeartRateFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(HEART_RATE_OFFSET, HEART_RATE_LENGTH);
		}
		
		public static char[] GetBOLevelFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(BO_LEVEL_OFFSET, BO_LEVEL_LENGTH);
		}
		
		public static char[] GetJointDataFromMessage(char[] message)
		{
			_message = message;
			return GetValueFromMessage(JOINT_DATA_OFFSET, _message.Length - JOINT_DATA_OFFSET);
		}
		
		#endregion
		
		#region HelperMethods
		
		private static char[] GetIndivoIdFromMessage()
		{
			return GetValueFromMessage(INDIVO_USER_ID_OFFSET, INDIVO_USER_ID_LENGTH);
		}
		
		private static char[] GetExerciseIdFromMessage()
		{
			return GetValueFromMessage(EXERCISE_ID_OFFSET, EXERCISE_ID_LENGTH);
		}
		
		private static char[] GetCommandFromMessage()
		{
			return GetValueFromMessage(COMMAND_OFFSET, COMMAND_LENGTH);
		}
		
		private static char[] GetMETFromMessage()
		{
			return GetValueFromMessage(MET_OFFSET, MET_LENGTH);
		}
		
		private static char[] GetHeartRateFromMessage()
		{
			return GetValueFromMessage(HEART_RATE_OFFSET, HEART_RATE_LENGTH);
		}
		
		private static char[] GetBOLevelFromMessage()
		{
			return GetValueFromMessage(BO_LEVEL_OFFSET, BO_LEVEL_LENGTH);
		}
		
		private static char[] GetJointDataFromMessage()
		{
			return GetValueFromMessage(JOINT_DATA_OFFSET, _message.Length - JOINT_DATA_OFFSET);
		}
		
		private static char[] GetValueFromMessage(int offset, int length)
		{
			if (_message == null || _message.Length == 0)
				throw new Exception("Message has not been set or has no data");
			
			if (offset + length > _message.Length)
			{
				throw new ArgumentException("Offset + Length can not be greater than the message length");
			}
			
			char[] val = new char[length];
			for (int i = 0; i < length; i++)
			{
				if (_message[offset + i] == '\0')
					break;
				
				val[i] = _message[offset + i];
			}
			
			return val;
		}
		
		#endregion
	}
}

