using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class Student : BaseInfo
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProgramId { get; set; }
        public int BatchId { get; set; }
        public string Roll { get; set; }  
    }
}
