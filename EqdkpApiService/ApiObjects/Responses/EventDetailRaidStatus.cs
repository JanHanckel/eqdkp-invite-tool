using System.Collections.Generic;
using System.Xml.Serialization;

namespace EqdkpApiService.ApiObjects
{
    [XmlType(AnonymousType = true)]
    public class EventDetailRaidStatus : Raidstatus
    {
        [XmlElement("categories")]        
        public Categories Categories;
    }

    [XmlType(AnonymousType = true)]
    public class Categories
    {
        [XmlElement("category1")]
        public Category Category_Heal;

        [XmlElement("category2")]
        public Category Category_Tank;

        [XmlElement("category3")]
        public Category Category_Ranged;

        [XmlElement("category4")]
        public Category Category_Melee;

        public IEnumerable<Category> AllCategories => new List<Category>
        {
            Category_Heal,
            Category_Tank,
            Category_Ranged,
            Category_Melee
        };
    }

    [XmlType(AnonymousType = true)]
    public class Category
    {
        [XmlElement("id")]
        public int ID;

        [XmlElement("name")]
        public string Name;

        [XmlElement("color")]
        public string Color;

        [XmlElement("count")]
        public int Count;

        [XmlElement("maxcount")]
        public int Maxcount;

        [XmlArray("chars")]
        [XmlArrayItem("char")]
        public Character[] Characters;
    }
}
