using System;
using System.Collections.Generic;
using IndivoClient;

namespace CardiacRehabIndivoClient
{
	public class DataRecorder
	{
		private IndivoConsumer _indivoClient = null;
		private string _consumerKey = "chrome";
		private string _consumerSecret = "chrome_secret65238";
		private string _baseUrl = "http://184.106.136.151:8000";
		
		public string AccountID { get; set; }
		
		public DataRecorder()
		{
		}
		
		public bool Record(string recordId, List<string> data)
		{
			ExerciseResult result = CreateExerciseResultFromRawData(data);
			
			if (!String.IsNullOrEmpty(this.AccountID))
			{
				string docId = _indivoClient.Records_X_DocumentsPost(recordId, null, SerializationHelper.SerializeObject<ExerciseResult>(result), "application/xml", new KeyValuePair<string, object>());
			}
			
			return true;
		}
		
		public string Login(string userName, string password)
		{
			string accountId = string.Empty;
			
			_indivoClient = new IndivoConsumer(_consumerKey, _consumerSecret, _baseUrl);
			accountId = _indivoClient.OAuthInternalSessionCreatePost(
			                                            userName,
			                                            password,
			                                            new KeyValuePair<string, object>());
			return accountId;
		}
		
		private ExerciseResult CreateExerciseResultFromRawData(List<string> data)
		{
			ExerciseResult er = new ExerciseResult();
			ExerciseResultExerciseGroup exerciseGroup = new ExerciseResultExerciseGroup();
			
			foreach (string dataMessage in data)
			{
				
			}
			
			return er;
		}
}
}

