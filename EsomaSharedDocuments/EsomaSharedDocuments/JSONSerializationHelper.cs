using System;
using System.Web.Script.Serialization;

namespace EsomaSharedDocuments
{
	public class JSONSerializationHelper
	{
		public static T DeserializeString<T>(string jsonString)
		{
			T obj = default(T);
			
			JavaScriptSerializer ser =  new JavaScriptSerializer();
			
			try
			{
				obj = ser.Deserialize<T>(jsonString);
			}
			catch { } // just eating this and returning empty for now
			
			return obj;
		}
		
		public static string SerializeObject<T>(T obj)
		{
			string serializedObj = string.Empty;
			
			JavaScriptSerializer ser = new JavaScriptSerializer();
			
			try
			{
				serializedObj = ser.Serialize(obj);
			}
			catch { } // just eating this and returning empty for now
			
			return serializedObj;
		}
	}
}

