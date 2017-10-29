using EqdkpApiService.ApiObjects;
using EqdkpWindowsNotifier.Objects.GameObjects;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace EqdkpWindowsNotifier.Service
{
    public class WowAddonService
    {
        private IEnumerable<Player> _Players;
        private IEnumerable<Event> _Events;

        public WowAddonService()
        {

        }

        public void SaveRaidsToAddon(DataService dataService)
        {
            _Players = GetPlayers(dataService);
            _Events = GetEvents(dataService);

            var raids = DataConverter.Convert(_Events);
            var luaData = LuaDataSerializer.Convert(raids);

            FileHandler.SaveAddonData(dataService.GetSettings().WowPath, "raidData.lua", luaData);
        }

        public void SaveRoleData(DataService dataService)
        {
            var roles = GetRoles(dataService);
            var luaData = LuaDataSerializer.Convert(roles);

            FileHandler.SaveAddonData(dataService.GetSettings().WowPath, "roleData.lua", luaData);
        }

        public void MyCharacterData(DataService dataService)
        {
            var characters = GetCharacters(dataService);
            var luaData = LuaDataSerializer.Convert(characters);

            FileHandler.SaveAddonData(dataService.GetSettings().WowPath, "characterData.lua", luaData);
        }

        private Characters GetCharacters(DataService dataService)
        {
            var firstEvent = GetEvents(dataService).First();
            var characters = firstEvent.Details.Characters.Select(s => new Objects.GameObjects.Character
            {                
                CharacterID = s.ID,
                Name = s.Name,
                ClassID = s.Class == 0 ? s.ClassID : s.Class,
                ClassName = _Players.FirstOrDefault(p => p.Name == s.Name).ClassName,
                Note = s.Note,
                Roles = s.Roles.Select(r => new Objects.GameObjects.Role {
                    RoleID = r.ID,
                    Name = r.Name
                }).ToList()                
            });

            return new Characters { Character = characters.ToList() };
        }

        private Roles GetRoles(DataService dataService)
        {
            var firstEvent = GetEvents(dataService).First();

            var roles = firstEvent.Details.RaidStatus.status_confirmed.Categories.AllCategories.Select(s => new Objects.GameObjects.Role
            {
                RoleID = s.ID,
                Name = s.Name                
            });

            return new Roles { Role = roles.ToList() };
        }

        private IEnumerable<Player> GetPlayers(DataService dataService)
        {
            if (_Players == null)
                return dataService.GetPlayers();
            return _Players;
        }

        private IEnumerable<Event> GetEvents(DataService dataService)
        {
            if (_Events == null)
                return dataService.GetEvents();
            return _Events;
        }
    }
}
