using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class Department : BaseInfo
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } 
    }
}
