using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    //[Serializable]
    public class User : BaseInfo
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; } 

        public string DecryptedPassword
        {
            get
            {
                return Utilites.Decrypt(Password);
            }
        }

    }


}
