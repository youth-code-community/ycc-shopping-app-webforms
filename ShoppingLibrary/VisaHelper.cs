using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

namespace ShoppingLibrary
{
    public enum PaymentStatus { OK, ERROR }

    public class VisaHelper
    {
        private string CallID;

        public VisaHelper(string callid)
        {
            CallID = callid;
        }

        public string GetVisaDataForBuyer()
        {
            string data = "";
            string baseUri = "wallet-services-web/";
            string apiNameUri = "payment/data/" + CallID;
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string queryString = "apikey=" + apiKey + "&datalevel=SUMMARY";

            string requestUrl = ConfigurationManager.AppSettings["visaUrl"] + baseUri + apiNameUri + "?" + queryString;
            string xpaytoken = GetXPayToken(apiNameUri, "apikey=" + apiKey, "");

            HttpWebRequest webRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.Accept = "application/json";
            webRequest.ContentType = "application/json";
            webRequest.Headers["x-pay-token"] = xpaytoken;

            try
            {
                using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                        {
                            data = reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        data = "";
                    }
                }
            }
            catch (WebException e)
            {
                data = "";
            }

            return data;
        }

        public string UpdateVisaAboutPayment(string requestBody)
        {
            string paymentStatus = "";
            string baseUri = "wallet-services-web/";
            string apiNameUri = "payment/info/" + CallID;
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string queryString = "apikey=" + apiKey;

            string requestUrl = ConfigurationManager.AppSettings["visaUrl"] + baseUri + apiNameUri + "?" + queryString;
            string xpaytoken = GetXPayToken(apiNameUri, "apikey=" + apiKey, requestBody);

            HttpWebRequest webRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
            webRequest.Method = "PUT";
            webRequest.Accept = "application/json";
            webRequest.ContentType = "application/json";
            webRequest.Headers["x-pay-token"] = xpaytoken;

            var requestStringBytes = Encoding.UTF8.GetBytes(requestBody);
            webRequest.GetRequestStream().Write(requestStringBytes, 0, requestStringBytes.Length);

            try
            {
                using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
                {
                    paymentStatus = response.StatusCode.ToString();
                }
            }
            catch (WebException e)
            {
                paymentStatus = "";
            }

            return paymentStatus;
        }

        private string GetXPayToken(string apiNameURI, string queryString, string requestBody)
        {
            string timestamp = GetTimestamp();
            string sharedSecret = ConfigurationManager.AppSettings["sharedSecret"];
            string sourceString = sharedSecret + timestamp + apiNameURI + queryString + requestBody;
            string hash = GetHash(sourceString);
            string token = "x:" + timestamp + ":" + hash;
            return token;
        }

        private string GetTimestamp()
        {
            long timeStamp = ((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds) / 1000;
            return timeStamp.ToString();
        }

        private string GetHash(string data)
        {
            string sharedSecret = ConfigurationManager.AppSettings["sharedSecret"];
            var hashString = new HMACSHA256(Encoding.ASCII.GetBytes(sharedSecret));
            var hashbytes = hashString.ComputeHash(Encoding.ASCII.GetBytes(data));
            string digest = String.Empty;

            foreach (byte b in hashbytes)
            {
                digest += b.ToString("x2");
            }

            return digest;
        }
    }
}
