using EqdkpApiService.ApiObjects;
using EqdkpWindowsNotifier.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Tools;

namespace EqdkpWindowsNotifier.Service
{
    public class DataService
    {
        private EqdkpApiService.EqdkpApiService _ApiService;

        private const string _PLAYERDATAFILENAME = "playerdata.dat";
        private const string _SETTINGSFILENAME = "settings.dat";

        private IEnumerable<Player> _Players;
        private SettingsData _Settings;

        public DataService()
        {
            _ApiService = new EqdkpApiService.EqdkpApiService();
        }

        public IEnumerable<Player> GetPlayers()
        {
            if (_Players == null)
            {
                var rawData = FileHandler.LoadLocalData(_PLAYERDATAFILENAME);
                PlayerData playerData;
                if (!TryParseXml(rawData))
                    playerData = null;
                else
                    playerData = Serializer.Deserialize<PlayerData>(rawData);

                if (playerData == null || playerData.ExpireDate < DateTime.Now || !playerData.Player.Any())
                {
                    playerData = new PlayerData();
                    playerData.Player = _ApiService.GetPlayers().ToArray();
                    playerData.ExpireDate = DateTime.Now.AddDays(1);
                    FileHandler.SaveLocalData(_PLAYERDATAFILENAME, Serializer.Serialize<PlayerData>(playerData));
                }
                _Players = playerData.Player;
            }
            return _Players;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _ApiService.GetEvents(_Players);
        }

        public SettingsData GetSettings()
        {
            if (_Settings == null)
            {
                UpdateSettings();
            }
            return _Settings;
        }

        public void UpdateSettings()
        {
            var rawData = FileHandler.LoadLocalData(_SETTINGSFILENAME);
            if (TryParseXml(rawData))
            {
                var settingsData = Serializer.Deserialize<SettingsData>(rawData);
                _Settings = settingsData;
            }
        }

        public void SaveSettings(SettingsData settings)
        {
            FileHandler.SaveLocalData(_SETTINGSFILENAME, Serializer.Serialize<SettingsData>(settings));
        }

        private bool TryParseXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
