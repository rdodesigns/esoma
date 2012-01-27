using System;
namespace EsomaSharedDocuments
{
	[Serializable]
	public class IndivoInitialization
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		
		public IndivoInitialization()
		{
		}
		
		public IndivoInitialization(string jsonString)
		{
			IndivoInitialization temp = JSONSerializationHelper.DeserializeString<IndivoInitialization>(jsonString);
			this.UserName = temp.UserName;
			this.Password = temp.Password;
		}
		
		public IndivoInitialization(string userName, string password)
		{
			this.UserName = userName;
			this.Password = password;
		}

		public override string ToString()
		{
			return JSONSerializationHelper.SerializeObject<IndivoInitialization>(this);
		}
	}
}

