using LogLayer.BusinessObject;
using LogLayer.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLayer.BusinessLogic
{
    public class LoginLogManager
    {
        public static int Insert(LoginLog loginLog)
        {
            int id = SQLLoginLog.Insert(loginLog);
            return id;
        }

        public static List<LoginLog> LoginLogGetAll()
        {
            List<LoginLog> list = SQLLoginLog.LoginLogGetAll();
            return list;
        }

        public static int InsertLog(string loginId, string password, int loginTypeId, bool isSuccess, string ipAddress, string message, DateTime createdDate)
        {
            LoginLog loginLog = new LoginLog();

            loginLog.LoginId = loginId;
            loginLog.Password = password;
            loginLog.LoginTypeId = loginTypeId;
            loginLog.IsSuccess = isSuccess;
            loginLog.IPAddress = ipAddress;
            loginLog.Details = message;
            loginLog.CreatedDate = createdDate;

            int id = Insert(loginLog);
            return id;
        }
    }
}
