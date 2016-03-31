using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.Entities
{
    [Table("Territories")]
    public class Territory
    {
        private EntityRef<Region> region = new EntityRef<Region>();

        [Association(Storage = "region", ThisKey = "RegionID", OtherKey = "RegionID")]
        public Region Region
        {
            get { return region.Entity; }
            set { region.Entity = value; }
        }

        [PrimaryKey]
        public string TerritoryID { get; set; }

        [Column, NotNull]
        public string TerritoryDescription { get; set; }

        [Column, NotNull]
        public int? RegionID;
    }
}
