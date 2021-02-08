using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class Gender : BaseInfo
    {
        public int Id { get; set; } 
        public string GenderName { get; set; }   
    }
}
