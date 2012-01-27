using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Net;
using System.Web;
using System.IO;
using System.Collections;

namespace IndivoClient
{
    public class IndivoConsumer
    {
        string _consumerKey;
        string _consumerSecret;
        string _accessToken;
        string _accessTokenSecret;
        string _baseUrl;
		
		public IndivoConsumer(string consumerKey, string consumerSecret, string baseUrl)
		{
			_consumerKey = consumerKey;
			_consumerSecret = consumerSecret;
			_baseUrl = baseUrl;
		}
		
        public IndivoConsumer(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, string baseUrl)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;
            _baseUrl = baseUrl;
        }

        public string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

        public string AccessTokenSecret
        {
            get { return _accessTokenSecret; }
            set { _accessTokenSecret = value; }
        }

        #region Accounts API

        public string Accounts_X_RecordsGet(String accountId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records for account: " + accountId);

            string restbase = _baseUrl + "/accounts/" + accountId + "/records/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, null, "GET", "text/plain");
            return fromRequest;
        }

        public string Accounts_X_InboxGet(String accountId, string include_archive, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/accounts/" + accountId + "/inbox/";

            if (!String.IsNullOrEmpty(pagingOrderQuery))
                pagingOrderQuery += "&";

            pagingOrderQuery += Utils.GetUrlParameterFromValue("include_archive", include_archive);

            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Accounts_X_Inbox_X_Get(String accountId, string messageId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/accounts/" + accountId + "/inbox/" + messageId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Accounts_X_Inbox_X_ArchivePost(String accountId, string messageId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/accounts/" + accountId + "/inbox/" + messageId + "/archive";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Accounts_X_Inbox_X_Attachments_X_AcceptPost(String accountId, string messageId, int attachmentNum, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/accounts/" + accountId + "/inbox/" + messageId + "/attachments/" + attachmentNum + "/accept";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Accounts_X_Inbox_X_Put(String accountId, string messageId, string subject, string message, string severity, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/accounts/" + accountId + "/inbox/" + messageId;
            string body = string.Format("{0}&{1}&{2}&{3}",
                Utils.GetUrlParameterFromValue("subject", subject),
                Utils.GetUrlParameterFromValue("message", message),
                Utils.GetUrlParameterFromValue("severity", severity));

            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", "application/x-www-form-urlencoded");
            return fromRequest;
        }

        #endregion

        #region Records API

        public string Records_X_Get(String recordId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_AppsGet(String recordId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/apps/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsSpecialContactGet(String recordId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/special/contact";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsSpecialContactPut(String recordId, object body, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/special/demographics";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", "application/xml", "plain/text");
            return fromRequest;
        }

        public string Records_X_DocumentsSpecialDemographicsGet(String recordId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/special/demographics";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsSpecialDemographicsPut(String recordId, object body, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/special/demographics";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT");
            return fromRequest;
        }

        public string Records_X_DocumentsGet(String recordId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsPost(String recordId, string pagingOrderQuery, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Records_X_DocumentsTypes_X_Get(String recordId, string typeId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/types/" + typeId + "/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsByTypeGet(String recordId, string type, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/";
            if (!String.IsNullOrEmpty(pagingOrderQuery))
                pagingOrderQuery += "&";

            pagingOrderQuery += Utils.GetUrlParameterFromValue("type", type);

            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_Documents_X_Get(String recordId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_Documents_X_Delete(String recordId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_Documents_X_MetaGet(String recordId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_Documents_X_StatusHistoryGet(String recordId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/status-history";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_Documents_X_VersionsGet(String recordId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/versions/";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsExternal_X_X_MetaGet(String recordId, string appId, string externalId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/external/" + appId + "/" + externalId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_DocumentsExternal_X_X_Put(String recordId, string appId, string externalId, object body, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/external/" + appId + "/" + externalId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT");
            return fromRequest;
        }

        public string Records_X_Documents_X_LabelPut(String recordId, string documentId, object body, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/label";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", "text/plain");
            return fromRequest;
        }

        public string Records_X_Documents_X_ReplacePost(String recordId, string documentId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/replace";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Records_X_Documents_X_SetStatusPost(String recordId, string documentId, string reason, string status, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string body = string.Format("{0}&{1}", Utils.GetUrlParameterFromValue("reason", reason), Utils.GetUrlParameterFromValue("status", status));
            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/set-status";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", "application/x-www-form-urlencoded");
            return fromRequest;
        }

        public string Records_X_DocumentsExternal_X_X_LabelPut(String recordId, string appId, string externalId, object body, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/external/" + appId + "/" + externalId + "/label";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", "text/plain");
            return fromRequest;
        }

        public string Records_X_Documents_X_Rels_X_Get(String recordId, string documentId, string relationType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/rels/" + relationType + "/";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, "GET");
            return fromRequest;
        }

        public string Records_X_Documents_X_Rels_X_Post(String recordId, string documentId, string relationType, string relatedDocumentId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/rels/" + relationType + "/";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Records_X_Documents_X_Rels_X_X_Put(String recordId, string documentId, string relationType, string relatedDocumentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/rels/" + relationType + "/" + relatedDocumentId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, "PUT");
            return fromRequest;
        }

        public string Records_X_Documents_X_Rels_X_External_X_X_Put(String recordId, string documentId, string relationType, string appId, string externalId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/documents/" + documentId + "/rels/" + relationType + "/external/" + appId + "/" + externalId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", requestContentType);
            return fromRequest;
        }

        public string Records_X_Documents_X_ReplaceExternal_X_Put(String recordId, string appId, string externalId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/replace/external/" + appId + "/" + externalId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", requestContentType);
            return fromRequest;
        }

        public string Records_X_Inbox_X_Put(String recordId, string messageId, string subject, string message, string severity, int numAttachments, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/inbox/" + messageId;
            string body = string.Format("{0}&{1}&{2}&{3}",
                Utils.GetUrlParameterFromValue("subject", subject),
                Utils.GetUrlParameterFromValue("message", message),
                Utils.GetUrlParameterFromValue("severity", severity),
                Utils.GetUrlParameterFromValue("num_attachments", numAttachments.ToString()));

            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", "application/x-www-form-urlencoded");
            return fromRequest;
        }

        public string Records_X_Inbox_X_Post(String recordId, string messageId, string subject, string message, string severity, int numAttachments, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/inbox/" + messageId;
            string body = string.Format("{0}&{1}&{2}&{3}",
                Utils.GetUrlParameterFromValue("subject", subject),
                Utils.GetUrlParameterFromValue("message", message),
                Utils.GetUrlParameterFromValue("severity", severity),
                Utils.GetUrlParameterFromValue("num_attachments", numAttachments.ToString()));

            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", "application/x-www-form-urlencoded");
            return fromRequest;
        }

        public string Records_X_Inbox_X_Attachments_X_Put(String recordId, string messageId, int attachmentNum, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/inbox/" + messageId + "/attachments/" + attachmentNum;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", requestContentType);
            return fromRequest;
        }

        public string Records_X_Inbox_X_Attachments_X_Post(String recordId, string messageId, int attachmentNum, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/inbox/" + messageId + "/attachments/" + attachmentNum;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Records_X_NotifyPost(String recordId, string content, string appUrl, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/notify";
            string body = string.Format("{0}&{1}&{2}",
                Utils.GetUrlParameterFromValue("content", content),
                Utils.GetUrlParameterFromValue("app_url", appUrl),
                Utils.GetUrlParameterFromValue("document_id", documentId));
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", "application/x-www-form-urlencoded");
            return fromRequest;
        }

        public string Records_X_Apps_X_DocumentsGet(String recordId, string appId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/apps/" + appId + "/documents/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Records_X_Apps_X_Documents_X_Get(String recordId, string appId, string documentId, string responseContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/apps/" + appId + "/documents/" + documentId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, null, "GET", "application/xml", responseContentType);
            return fromRequest;
        }

        public string Records_X_Apps_X_Documents_X_MetaGet(String recordId, string appId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/records/" + recordId + "/apps/" + appId + "/documents/" + documentId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        #endregion

        #region Carenets API

        public string Carenets_X_DocumentsGet(String carenetId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_DocumentsSpecialContactGet(String carenetId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/special/contact";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_DocumentsSpecialDemographicsGet(String carenetId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/special/demographics";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_DocumentsTypes_X_Get(String carenetId, string typeId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/types/" + typeId + "/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_DocumentsByTypeGet(String carenetId, string type, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/";
            if (!String.IsNullOrEmpty(pagingOrderQuery))
                pagingOrderQuery += "&";

            pagingOrderQuery += Utils.GetUrlParameterFromValue("type", type);

            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_Documents_X_Get(String carenetId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/" + documentId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_Documents_X_MetaGet(String carenetId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/" + documentId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_Documents_X_StatusHistoryGet(String carenetId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/" + documentId + "/status-history";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_Documents_X_VersionsGet(String carenetId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/" + documentId + "/versions/";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_DocumentsExternal_X_X_MetaGet(String carenetId, string appId, string externalId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/external/" + appId + "/" + externalId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Carenets_X_Documents_X_Rels_X_Get(String carenetId, string documentId, string relationType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/carenets/" + carenetId + "/documents/" + documentId + "/rels/" + relationType + "/";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, "GET");
            return fromRequest;
        }

        #endregion

        #region Apps API

        public string Apps_X_DocumentsGet(String appId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Apps_X_DocumentsPost(String appId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "POST", requestContentType);
            return fromRequest;
        }

        public string Apps_X_Documents_X_Get(String appId, string documentId, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/" + documentId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, null, "GET", requestContentType);
            return fromRequest;
        }

        public string Apps_X_Documents_X_MetaGet(String appId, string documentId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/" + documentId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Apps_X_DocumentsExternal_X_Put(string appId, string externalId, object body, string requestContentType, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/external/" + externalId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", requestContentType);
            return fromRequest;
        }

        public string Apps_X_DocumentsExternal_X_MetaGet(string appId, string externalId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/external/" + externalId + "/meta";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Apps_X_Documents_X_LabelPut(String appId, string documentId, object body, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/documents/" + documentId + "/label";
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, body, "PUT", "text/plain");
            return fromRequest;
        }

        public string Apps_X_InboxGet(String appId, string pagingOrderQuery, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/inbox/";
            string fromRequest = Utils.MakeRequest(restbase, pagingOrderQuery, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Apps_X_Inbox_X_Get(String appId, string messageId, KeyValuePair<String, Object> options)
        {
            Console.WriteLine("Getting Records:");

            string restbase = _baseUrl + "/apps/" + appId + "/inbox/" + messageId;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return fromRequest;
        }

        public string Apps_X_Inbox_X_Attachments_X_Get(String appId, string messageId, int attachmentNum, string respnseContentType, KeyValuePair<String, Object> options)
        {
            string restbase = _baseUrl + "/apps/" + appId + "/inbox/" + messageId + "/attachments/" + attachmentNum;
            string fromRequest = Utils.MakeRequest(restbase, string.Empty, _consumerKey, _consumerSecret, _accessToken, _accessTokenSecret, null, "GET", "application/xml", respnseContentType);
            return fromRequest;
        }

        #endregion

        #region OAuth API

        public string OAuthInternalSessionCreatePost(string userName, string password, KeyValuePair<string, object> options)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            string restbase = _baseUrl + "/oauth/internal/session_create";
            string body = string.Format("{0}&{1}",
                                        Utils.GetUrlParameterFromValue("username", userName),
                                        Utils.GetUrlParameterFromValue("password", password));
            string fromRequest = Utils.MakeAdminRequest(restbase, string.Empty, _consumerKey, _consumerSecret, userName, password, body, "POST", "application/x-www-form-urlencoded", "text/plain");
            System.Net.ServicePointManager.Expect100Continue = true;
			
			if (!String.IsNullOrEmpty(fromRequest))
			{
				oAuthLoginResponse response = new oAuthLoginResponse(fromRequest);
				_accessToken = response.AccessToken;
				_accessTokenSecret = response.AccessTokenSecret;
			
	            return response.AccountID;
			}
			
			return String.Empty;
        }

        #endregion
    }
}

