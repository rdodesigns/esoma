using System;
using System.Data;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;

namespace IndivoClient
{
    public class Utils
    {
        public static string MakeAdminRequest(
                                    String relativePath,
                                    Object queryString,
                                    String consumerKey,
                                    String consumerSecret,
                                    String userName,
                                    String password,
                                    Object requestBody,   // String or byte[]
                                    String reqMeth,
                                    String requestContentType,
                                    String responseContentType)
        {
            // Form the full REST request url
            Uri url = new Uri(relativePath + queryString);

            // Instantiate OAuthBase and declare variables
            oAuthBase oAuth = new oAuthBase();
            string nonce = oAuth.GenerateNonce();
            string timestamp = oAuth.GenerateTimeStamp();
            string normUrl = string.Empty;
            string normParams = string.Empty;

            // Create an OAuth signature
            string signature = oAuth.GenerateSignature(url,
                consumerKey, consumerSecret, null, null, userName, password,
                reqMeth, timestamp, nonce, IndivoClient.oAuthBase.SignatureTypes.HMACSHA1,
                out normUrl, out normParams);

            string authHeadParams = getAuthHeadParams(nonce, timestamp, consumerKey, null, signature);

            return MakeWebRequest(normUrl, authHeadParams, reqMeth, requestBody, requestContentType, responseContentType);
        }

        public static string MakeRequest(
                                    String relativePath,
                                    Object queryString,
                                    String consumerKey,
                                    String consumerSecret,
                                    String token,
                                    String secret)
        {
            return MakeRequest(relativePath, queryString, consumerKey, consumerSecret, token, secret, null, "GET");
        }
        public static string MakeRequest(
                                    String relativePath,
                                    Object queryString,
                                    String consumerKey,
                                    String consumerSecret,
                                    String token,
                                    String secret,
                                    Object requestBody)   // String or byte[]
        {
            return MakeRequest(relativePath, queryString, consumerKey, consumerSecret, token, secret, requestBody, "GET");
        }

        public static string MakeRequest(
                                    String relativePath,
                                    Object queryString,
                                    String consumerKey,
                                    String consumerSecret,
                                    String token,
                                    String secret,
                                    Object requestBody, // String or byte[]
                                    String requestMethod)
        {
            return MakeRequest(relativePath, queryString, consumerKey, consumerSecret, token, secret, requestBody, requestMethod, "application/xml");
        }

        public static string MakeRequest(
                                    String relativePath,
                                    Object queryString,
                                    String consumerKey,
                                    String consumerSecret,
                                    String token,
                                    String secret,
                                    Object requestBody, // String or byte[]
                                    String requestMethod,
                                    String requestContentType)
        {
            return MakeRequest(relativePath, queryString, consumerKey, consumerSecret, token, secret, requestBody, requestMethod, requestContentType, "application/xml");
        }

        public static string MakeRequest(
                                    String relativePath,
                                    Object queryString,
                                    String consumerKey,
                                    String consumerSecret,
                                    String token,
                                    String secret,
                                    Object requestBody,   // String or byte[]
                                    String reqMeth,
                                    String requestContentType,
                                    String responseContentType)
        {
            // Form the full REST request url
            Uri url = new Uri(relativePath + queryString);

            // Instantiate OAuthBase and declare variables
            oAuthBase oAuth = new oAuthBase();
            string nonce = oAuth.GenerateNonce();
            string timestamp = oAuth.GenerateTimeStamp();
            string normUrl = string.Empty;
            string normParams = string.Empty;

            // Create an OAuth signature
            string signature = oAuth.GenerateSignature(url,
                consumerKey, consumerSecret, token, secret, null, null,
                reqMeth, timestamp, nonce, IndivoClient.oAuthBase.SignatureTypes.HMACSHA1,
                out normUrl, out normParams);

            string authHeadParams = getAuthHeadParams(nonce, timestamp, consumerKey, token, signature);

            return MakeWebRequest(normUrl, authHeadParams, reqMeth, requestBody, requestContentType, responseContentType);
        }

        protected static string MakeWebRequest(string call, string authhead, string requestMethod, object requestBody, string requestContentType, string responseContentType)
        {
            byte[] body = null;

            if (requestBody != null)
            {
                if (requestBody is string)
                    body = System.Text.Encoding.UTF8.GetBytes((string)requestBody);
                else
                    body = requestBody as byte[];
            }

            // Make web request
            HttpWebRequest request = WebRequest.Create(call) as HttpWebRequest;
            request.Method = requestMethod;
            request.Headers.Add("Authorization", authhead);
            request.ContentType = requestContentType;
            request.Accept = "*/*"; //responseContentType;
			request.Headers.Add("Accept-Encoding", "gzip, deflate");
			request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            if (body != null)
            {
                request.ContentLength = body.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(body, 0, body.Length);
                }
            }

            //TODO: Make this configurable or find better way to log - MAG 1/19/2012
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Downloads\Console.txt");

            string responseValue = null;
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader responseStreamReader = new StreamReader(response.GetResponseStream()))
					{
						responseValue = responseStreamReader.ReadToEnd();
					}
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();

                        //file.WriteLine(text);
                        //TODO: Log error
                    }
                }
            }

            return responseValue;
        }

        public static void PrintValues(DataSet dataSet, string label)
        {
            //Console.WriteLine(label);
            foreach (DataTable table in dataSet.Tables)
            {
                PrintValues(table, label);
            }
        }

        public static void PrintValues(DataTable table, string label)
        {
            //Console.WriteLine(label);
            Console.WriteLine("Table: " + table.TableName);
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }

        private static String getAuthHeadParams(string nonce, string timestamp, string consumerKey, string token, string signature)
        {
            string authorizationHeaderParams = String.Empty;
            authorizationHeaderParams += "OAuth ";
            authorizationHeaderParams += "realm=" + "\"\",";
            authorizationHeaderParams += "oauth_nonce=" + "\"" +
                Uri.EscapeDataString(nonce) + "\",";
            authorizationHeaderParams +=
                "oauth_signature_method=" + "\"" +
                Uri.EscapeDataString("HMAC-SHA1") +
                "\",";
            authorizationHeaderParams += "oauth_timestamp=" + "\"" +
                Uri.EscapeDataString(timestamp) + "\",";
            authorizationHeaderParams += "oauth_consumer_key="
                + "\"" + Uri.EscapeDataString(consumerKey) + "\",";

            if (!String.IsNullOrEmpty(token))
            {
                authorizationHeaderParams += "oauth_token=" + "\"" +
                    Uri.EscapeDataString(token) + "\",";
            }

            authorizationHeaderParams += "oauth_signature=" + "\""
                + Uri.EscapeDataString(signature) + "\",";
            authorizationHeaderParams += "oauth_version=" + "\"" +
                Uri.EscapeDataString("1.0") + "\"";
            return authorizationHeaderParams;
        }

        public static ArrayList getRecordId(DataSet dataSet)
        {
            ArrayList list = new ArrayList();
            Console.WriteLine("RecordIDs:");
            foreach (DataTable table in dataSet.Tables)
            {
                if (table.TableName == "Record")
                {
                    //PrintValues(table, "Records");
                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(row[0].ToString());
                        Console.WriteLine(row[0].ToString());
                    }
                }
            }
            Console.WriteLine("");
            return list;
        }

        public static ArrayList getDocumentId(DataSet dataSet)
        {
            ArrayList list = new ArrayList();
            Console.WriteLine("DocumentIDs:");
            foreach (DataTable table in dataSet.Tables)
            {
                if (table.TableName == "Document")
                {
                    //PrintValues(table, "Documents");
                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(row[4].ToString());
                        Console.WriteLine(row[1].ToString() + ": " + row[4].ToString());
                    }
                }
            }
            Console.WriteLine("");
            return list;
        }
        public static string GetUrlParameterFromValue(string paramName, string paramValue)
        {
            return string.Format("{0}={1}", paramName, HttpUtility.UrlEncode(paramValue));
        }
    }
}

