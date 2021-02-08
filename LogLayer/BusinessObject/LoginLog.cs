using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLayer.BusinessObject
{
    public class LoginLog
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int LoginTypeId { get; set; }
        public bool IsSuccess { get; set; }
        public string IPAddress { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
