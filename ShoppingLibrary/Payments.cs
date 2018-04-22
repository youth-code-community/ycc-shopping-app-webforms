using System;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections;


namespace ShoppingLibrary
{
    public class Payments
    {
        private string callId;
        private float moneyPaid;
        private VisaHelper VisaHelper;
        private JObject reqBody;

        public Payments(string CallID, float MoneyPaid)
        {
            callId = CallID;
            moneyPaid = MoneyPaid;
            VisaHelper = new VisaHelper(CallID);
            reqBody = new JObject();
            reqBody.Add("currencyCode", JToken.FromObject("USD"));
        }

        public (bool, Hashtable) MakePayment()
        {
            string info = VisaHelper.GetVisaDataForBuyer();
            if (info.Length == 0) return (false, null);
            float total = GetPaymentTotal(info);
            Hashtable buyerInfo = GetBuyerInfo(info);
            JObject jObject = JObject.FromObject(info);

            if (Math.Abs(moneyPaid - total) < 10E-6) //if moneyPaid == total
            {
                reqBody.Add("total", JToken.FromObject(moneyPaid.ToString()));
                reqBody.Add("subTotal", jObject["subTotal"]);
                return (true, buyerInfo);
            }
            else return (false, null);
        }

        public bool UpdatePayment(int orderID, bool paymentSuccessfull)
        {
            string requestBody = "", 
            eventType = paymentSuccessfull ? "Confirm" : "Cancel";

            reqBody.Add("eventType", JToken.FromObject(eventType));
            reqBody.Add("orderId", JToken.FromObject(orderID.ToString()));
            reqBody.Add("reason", JToken.FromObject(eventType + " order"));

            JObject jObject = new JObject();
            jObject.Add("orderInfo", reqBody);
            requestBody = jObject.ToString();

            string[] substrings = requestBody.Split(new char[]{' ', '\n', '\t'});
            StringBuilder stringBuilder = new StringBuilder();
            foreach(string sub in substrings)
            {
                stringBuilder.Append(sub);
            }
            requestBody = stringBuilder.ToString();

            string status = VisaHelper.UpdateVisaAboutPayment(requestBody);
            return status.Contains("200");
        }

        private float GetPaymentTotal(string response)
        {
            JObject jObject = JObject.Parse(response);
            string total = jObject["total"].ToString();
            return float.Parse(total);
        }

        private Hashtable GetBuyerInfo(string response)
        {
            JObject jObject = JObject.Parse(response);
            Hashtable buyer = new Hashtable();
            buyer["Fname"] = jObject["userData"]["userFirstName"].ToString();
            buyer["Lname"] = jObject["userData"]["userLastName"].ToString();
            buyer["EmailAddress"] = jObject["userData"]["userEmail"].ToString();
            buyer["PhoneNumber"] = jObject["userData"]["userMobile"].ToString();
            if (jObject["shippingAddress"]["verificationStatus"].ToString()
                == "NOT_VERIFIED")
            {
                buyer["ShippingAddress"] = null;
            }
            else
            {
                StringBuilder shippingAddr = new StringBuilder("");
                JToken saddr = jObject["shippingAddress"];
                shippingAddr.Append(saddr["personName"].ToString())
                            .Append("\n\n")
                            .Append(saddr["line1"].ToString())
                            .Append("\n")
                            .Append(saddr["city"].ToString())
                            .Append("\n")
                            .Append(saddr["stateProvinceCode"].ToString())
                            .Append("\n")
                            .Append(saddr["postalCode"].ToString())
                            .Append("\n")
                            .Append(saddr["countryCode"].ToString());
                buyer["ShippingAddress"] = shippingAddr.ToString();
            }
            StringBuilder billingAddr = new StringBuilder("");
            JToken baddr = jObject["billingAddress"];
            billingAddr.Append(baddr["personName"].ToString())
                        .Append("\n\n")
                        .Append(baddr["line1"].ToString())
                        .Append("\n")
                        .Append(baddr["city"].ToString())
                        .Append("\n")
                        .Append(baddr["stateProvinceCode"].ToString())
                        .Append("\n")
                        .Append(baddr["postalCode"].ToString())
                        .Append("\n")
                        .Append(baddr["countryCode"].ToString());
            buyer["BillingAddress"] = billingAddr.ToString();
            return buyer;
        }
    }
}
