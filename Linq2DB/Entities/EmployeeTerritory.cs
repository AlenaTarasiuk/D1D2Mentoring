using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.Entities
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        private EntityRef<Employee> employee = new EntityRef<Employee>();
        private EntityRef<Territory> territory = new EntityRef<Territory>();

        [Association(Storage = "employee", ThisKey = "EmployeeID", OtherKey="EmployeeID")]
        public Employee Employee
        {
            get { return employee.Entity; }
            set { employee.Entity = value; }
        }

        [Association(Storage="territory", ThisKey="TerritoryID", OtherKey="TerritoryID")]
        public Territory Territory
        {
            get { return territory.Entity; }
            set { territory.Entity = value; }
        }

        [Column, NotNull, PrimaryKey]
        public int? EmployeeID;

        [Column, NotNull, PrimaryKey]
        public string TerritoryID;
    }
}
