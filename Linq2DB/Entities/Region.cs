using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.Entities
{
    [Table("Region")]
    public class Region
    {
        [PrimaryKey, Identity]
        public int RegionID { get; set; }

        [Column, NotNull]
        public string RegionDescription { get; set; }
    }
}
