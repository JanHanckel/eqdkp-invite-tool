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
                || String.IsNullOrWhiteSpace(ConfigSettings.UserName)
                || String.IsNullOrWhiteSpace(ConfigSettings.Password)
                )
                throw new NullReferenceException("Configuration Values missing. Please check settings.");

            if (String.IsNullOrWhiteSpace(ConfigSettings.PasswordSalt))
                ConfigSettings.PasswordSalt = GetPasswordSalt();

            if(!CheckSession())            
                ConfigSettings.SessionID = GetSessionID();            
        }

        private bool CheckSession ()
        {
            var login = new SessionRequest
            {
                SessionID = ConfigSettings.SessionID
            };

            var apiUrl = "/api.php?function=get_salt";
            var request = new RestRequest(apiUrl, Method.POST);
            request.RequestFormat = DataFormat.Xml;
            request.AddBody(login);

            try
            {
                return HandleApiRequest<SessionResponse>(request).Valid;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GetPasswordSalt()
        {
            var login = new LoginRequest
            {
                User = ConfigSettings.UserName
            };

            var apiUrl = "/api.php?function=get_salt";
            var request = new RestRequest(apiUrl, Method.POST);
            request.RequestFormat = DataFormat.Xml;
            request.AddBody(login);

            return HandleApiRequest<SaltResponse>(request).Salt;
        }

        private string GetSessionID()
        {
            var login = new LoginRequest
            {
                User = ConfigSettings.UserName,
                Password = CreateSHAHash(ConfigSettings.Password, ConfigSettings.PasswordSalt)
            };

            var apiUrl = "/api.php?function=login";
            var request = new RestRequest(apiUrl, Method.POST);
            request.RequestFormat = DataFormat.Xml;
            request.AddBody(login);

            return HandleApiRequest<LoginResponse>(request).SessionID;
        }

        private Event[] GetEvents(bool raidsOnly = true, int number = 5)
        {
            if (!CheckSession())
                ConfigSettings.SessionID = GetSessionID();

            var apiUrl = "/api.php?function=calevents_list";

            var request = new RestRequest(apiUrl, Method.GET);
            request.RequestFormat = DataFormat.Xml;

            request.AddQueryParameter("raids_only", raidsOnly ? "1" : "0");
            request.AddQueryParameter("number", number.ToString());
            request.AddQueryParameter("s", ConfigSettings.SessionID);

            return HandleApiRequest<EventsResponse>(request).Events;
        }
        
        private T HandleApiRequest<T>(RestRequest request) where T : ApiResponse, new()
        {
            var response = (ApiResponse)SendApiRequest<T>(request);

            if (response.Status == 0)
                throw new Exception();
            else
                return (T)response;
        }

        private IRestResponse SendApiRequest<T>(RestRequest request) where T : ApiResponse, new()
        {
            var client = new RestClient("http://grauerrat.de");
            return client.Execute<T>(request);
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
