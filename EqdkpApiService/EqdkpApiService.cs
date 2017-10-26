﻿using EqdkpApiService.ApiObjects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

        public IEnumerable<Raid> GetRaids()
        {
            var raids = GetRaids(5);
            foreach(var raid in raids)
            {
                raid.Details = GetEventDetails(raid.EventID);
            }

            return raids;
        }

        public IEnumerable<Event> GetEvents()
        {
            var raids = GetEvents(true, 5);
            foreach (var raid in raids)
            {
                raid.Details = GetEventDetails(raid.EventID);
            }

            return raids;
        }

        private Raid[] GetRaids(int number)
        {
            var apiUrl = "/api.php?function=raids";

            var request = new RestRequest(apiUrl, Method.GET);
            request.RequestFormat = DataFormat.Xml;
            
            request.AddQueryParameter("number", number.ToString());

            return HandleApiRequest<RaidsResponse>(request).Raids;
        }

        private Event[] GetEvents(bool raidsOnly = true, int number = 5)
        {
            var apiUrl = "/api.php?function=calevents_list";

            var request = new RestRequest(apiUrl, Method.GET);
            request.RequestFormat = DataFormat.Xml;

            request.AddQueryParameter("raids_only", raidsOnly ? "1" : "0");
            request.AddQueryParameter("number", number.ToString());

            return HandleApiRequest<EventsResponse>(request).Events;            
        }

        private EventDetailResponse GetEventDetails(int eventID)
        {
            var apiUrl = "/api.php?function=calevents_details";

            var request = new RestRequest(apiUrl, Method.GET);
            request.RequestFormat = DataFormat.Xml;

            request.AddQueryParameter("eventid", eventID.ToString());            

            return HandleApiRequest<EventDetailResponse>(request);
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
            var response = client.Execute(request);

            var serializer = new XmlSerializer(typeof(T));
            T result = null;

            var xml = response.Content.Replace("\n", "");
            using (TextReader reader = new StringReader(xml))
            {

                result = (T)serializer.Deserialize(reader);
            }
            return (T)result;
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
