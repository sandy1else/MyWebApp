using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class AcademicSession : BaseInfo
    {
        public int Id { get; set; }
        public int AcademicSessionTypeId { get; set; }
        public string Code { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsNext { get; set; }  
    }
}
