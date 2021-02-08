using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class RoleMenu : BaseInfo
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }  
    }
}
