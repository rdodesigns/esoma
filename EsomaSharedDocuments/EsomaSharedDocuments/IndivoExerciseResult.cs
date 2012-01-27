using System;
using IndivoClient;

namespace EsomaSharedDocuments
{
	[Serializable]
	public class IndivoExerciseResult
	{
		public ExerciseResult Result { get; set; }
		public string AccountID { get; set; }
		
		public IndivoExerciseResult()
		{
		}
		
		public IndivoExerciseResult(string jsonString)
		{
			IndivoExerciseResult temp = JSONSerializationHelper.DeserializeString<IndivoExerciseResult>(jsonString);
			HydrateObject(temp.Result, temp.AccountID);
		}
		
		public IndivoExerciseResult(ExerciseResult result, string accountId)
		{
			HydrateObject(result, accountId);
		}
		
		public override string ToString ()
		{
			return JSONSerializationHelper.SerializeObject<IndivoExerciseResult>(this);
		}
		
		private void HydrateObject(ExerciseResult result, string accountId)
		{
			this.Result = result;
			this.AccountID = accountId;
		}
	}
}

