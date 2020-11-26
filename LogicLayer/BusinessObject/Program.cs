using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    [Serializable]
    public class Program
    {
        public int Id { get; set; }
        public int DeptId { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int TotalCredit { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}
