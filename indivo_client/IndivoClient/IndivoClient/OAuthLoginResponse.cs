using System;
using System.Web;
namespace IndivoClient
{
	public class oAuthLoginResponse
	{
		public string AccessTokenSecret { get; set; }
		public string AccessToken { get; set; }
		public string AccountID { get; set; }
		
		private const string TOKEN_SECRET = "oauth_token_secret";
		private const string TOKEN = "oauth_token";
		private const string ACCOUNT_ID = "account_id";
		
		
		public oAuthLoginResponse (string loginResponse)
		{
			if (String.IsNullOrEmpty(loginResponse))
				throw new ArgumentException("loginResponse cannot be null");
			
			foreach (String keyValue in loginResponse.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
			{
				string[] pair = keyValue.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
				string key = pair[0];
				string val = pair.Length > 1 ? HttpUtility.UrlDecode(pair[1]) : string.Empty;
				
				switch (key.ToLower())
				{
					case TOKEN_SECRET:
						this.AccessTokenSecret = val;
						break;
					case TOKEN:
						this.AccessToken = val;
						break;
					case ACCOUNT_ID:
						this.AccountID = val;
						break;
				}
			}
		}
	}
}

