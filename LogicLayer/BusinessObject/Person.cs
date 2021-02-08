using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class Person : BaseInfo
    {
        public int Id { get; set; }
        public int GenderId { get; set; }
        public int ReligionId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NID { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public string PhotoURL { get; set; }
    }
}
