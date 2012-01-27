using System;
using System.Xml.Serialization;
using System.IO;
namespace CardiacRehabIndivoClient
{
	public class SerializationHelper
	{
		public static string SerializeObject<T>(T obj)
		{
			string serializedValue = string.Empty;
			
			XmlSerializer xs = new XmlSerializer(typeof(T));
			TextWriter tw = new StreamWriter(serializedValue);
			xs.Serialize(tw, obj);
			
			return serializedValue;
		}
		
		public static T DeserializeObject<T>(string xmlData)
		{	
			T obj = default(T);
			
			if (!String.IsNullOrEmpty(xmlData))
			{
				XmlSerializer xs = new XmlSerializer(typeof(T));
				TextReader tr = new StringReader(xmlData);
				obj = (T)xs.Deserialize(tr);
			}
			
			return obj;
		}
	}
}

