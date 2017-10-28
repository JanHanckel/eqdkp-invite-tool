using EqdkpApiService.ApiObjects;
using EqdkpWindowsNotifier.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqdkpWindowsNotifier
{
    public static class DataConverter
    {
        public static Raids Convert(IEnumerable<Event> events)
        {
            var raids = new Raids();
            raids.Raid = new List<Objects.GameObjects.Raid>();

            ConvertEvents(events, raids);

            return raids;
        }

        private static void ConvertEvents(IEnumerable<Event> events, Raids raids)
        {
            foreach (var even in events)
            {
                Objects.GameObjects.Raid raid = ConvertEvent(even);
                raids.Raid.Add(raid);
            }
        }

        private static Objects.GameObjects.Raid ConvertEvent(Event even)
        {
            var raid = new Objects.GameObjects.Raid
            {
                EventID = even.EventID,
                Date = even.StartDate
            };

            ConvertDetails(even, raid);

            return raid;
        }

        private static void ConvertDetails(Event even, Objects.GameObjects.Raid raid)
        {
            foreach (var detail in even.Details.RaidStatus.AllStates)
            {
                RaidStatus status = ConvertDetail(detail);
                raid.RaidStates.Add(status);
            }
        }

        private static RaidStatus ConvertDetail(EventDetailRaidStatus detail)
        {
            var status = new RaidStatus
            {
                StatusID = detail.ID,
                Name = detail.Name
            };

            ConvertRoles(detail, status);

            return status;
        }

        private static void ConvertRoles(EventDetailRaidStatus detail, RaidStatus status)
        {
            foreach (var cat in detail.Categories.AllCategories)
            {
                Objects.GameObjects.Role role = ConvertRole(cat);
                status.Roles.Add(role);
            }
        }

        private static Objects.GameObjects.Role ConvertRole(Category category)
        {
            var role = new Objects.GameObjects.Role
            {
                RoleID = category.ID,
                Name = category.Name
            };

            ConvertCharacters(category, role);

            return role;
        }

        private static void ConvertCharacters(Category cat, Objects.GameObjects.Role role)
        {
            foreach (var cha in cat.Characters)
            {
                Objects.GameObjects.Character player = ConvertCharacter(cha);
                role.Players.Add(player);
            }
        }

        private static Objects.GameObjects.Character ConvertCharacter(EqdkpApiService.ApiObjects.Character character)
        {
            return new Objects.GameObjects.Character
            {
                CharcterID = character.ID,
                Name = character.Name,
                ClassID = character.ClassID,
                Note = character.Note
            };
        }
    }
}
