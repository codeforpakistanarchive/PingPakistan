using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace PingPakistan.Common
{
    public class SmileSMS
    {
        public class AuthenticationResponse
        {
            public string status { get; set; } // AUTH_FAILED
            public string sessionid { get; set; }
        }

        public class SendSMSResponse
        {
            public string status { get; set; } // SESSION_EXPIRED, QUOTA_ERROR, FAILED, WRONG_NUMBER, ACCEPTED
        }

        public static string MakeRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            //request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //var status = ((HttpWebResponse)response).StatusDescription;
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return responseFromServer;
        }

        private static AuthenticationResponse Authenticate()
        {
            return JsonConvert.DeserializeObject<AuthenticationResponse>(MakeRequest("http://api.smilesn.com/session?username=11&password=green9642"));
        }
        public static SendSMSResponse Send(string number, string msg)
        {
            var authResponse = Authenticate();
            SendSMSResponse response = new SendSMSResponse();
            response.status = authResponse.status;
            if (authResponse.status != "AUTH_FAILED")
            {
                response = JsonConvert.DeserializeObject<SendSMSResponse>(MakeRequest(string.Format("http://api.smilesn.com/sendsms?sid={0}&receivenum={1}&textmessage={2}", authResponse.sessionid, number, msg)));
            }
            return response;
        }
    }
}