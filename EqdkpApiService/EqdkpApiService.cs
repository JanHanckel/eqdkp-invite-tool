using EqdkpApiService.ApiObjects;
using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EqdkpApiService
{
    public class EqdkpApiService
    {
        public void Login()
        {
            if (String.IsNullOrWhiteSpace(ConfigSettings.ApiUrl)
                || String.IsNullOrWhiteSpace(ConfigSettings.ApiKey)
                )
                throw new NullReferenceException("Configuration Values missing. Please check settings.");
        }

        public void GetEvents()
        {
            var events = GetEventsIntern();
        }

        private Event[] GetEventsIntern(bool raidsOnly = true, int number = 5)
        {
            var apiUrl = "/api.php?function=calevents_list";

            var request = new RestRequest(apiUrl, Method.GET);
            request.RequestFormat = DataFormat.Xml;

            request.AddQueryParameter("raids_only", raidsOnly ? "1" : "0");
            request.AddQueryParameter("number", number.ToString());

            return HandleApiRequest<EventsResponse>(request).Events;
        }
        
        private T HandleApiRequest<T>(RestRequest request) where T : ApiResponse, new()
        {
            var response = SendApiRequest<T>(request);

            if (response.Status == 0)
                throw new Exception(response.Error);
            else
                return (T)response;
        }

        private T SendApiRequest<T>(RestRequest request) where T : ApiResponse, new()
        { 
            request.AddHeader("X-Custom-Authorization", $"token={ConfigSettings.ApiKey}&type=user");
            var client = new RestClient(ConfigSettings.ApiUrl);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        private string CreateSHAHash(string Password, string Salt)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PasswordAsByte = Encoding.UTF8.GetBytes(string.Concat(Password, Salt));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
    }
}
