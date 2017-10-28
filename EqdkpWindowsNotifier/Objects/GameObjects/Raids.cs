using System;
using System.Collections.Generic;

namespace EqdkpWindowsNotifier.Objects.GameObjects
{
    public class Raids
    {
        public Raids()
        {
            Raid = new List<Raid>();
        }

        public List<Raid> Raid { get; set; }
    }

    public class Raid
    {
        public Raid()
        {
            RaidStates = new List<RaidStatus>();
        }

        public int EventID { get; set; }

        public DateTime Date { get; set; }

        public List<RaidStatus> RaidStates { get; set; }
    }

    public class RaidStatus
    {
        public RaidStatus()
        {
            Roles = new List<Role>();
        }

        public int StatusID { get; set; }

        public string Name { get; set; }

        public List<Role> Roles { get; set; }
    }

    public class Role
    {
        public Role()
        {
            Players = new List<Character>();
        }

        public int RoleID { get; set; }

        public string Name { get; set; }

        public List<Character> Players { get; set; }
    }

    public class Character
    {
        public int CharcterID { get; set; }

        public string Name { get; set; }

        public int ClassID { get; set; }

        public string ClassName { get; set; }

        public string Note { get; set; }
    }
}
