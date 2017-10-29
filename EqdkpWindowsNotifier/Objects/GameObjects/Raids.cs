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

    public class Roles
    {
        public Roles()
        {
            Role = new List<Role>();
        }

        public List<Role> Role { get; set; }
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

    public class Characters
    {
        public Characters()
        {
            Character = new List<Character>();
        }

        public List<Character> Character { get; set; }
    }

    public class Character
    {
        public Character()
        {
            Roles = new List<Role>();
        }

        public int CharacterID { get; set; }

        public string Name { get; set; }

        public int ClassID { get; set; }

        public string ClassName { get; set; }

        public string Note { get; set; }

        public List<Role> Roles { get; set; }
    }
}
