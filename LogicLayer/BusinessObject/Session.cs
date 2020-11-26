using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    [Serializable]
    public class Session
    {
        public int Id { get; set; }
        public int SessionTypeId { get; set; }
        public string Code { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsNext { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}
