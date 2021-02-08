using LogLayer.BusinessObject;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLayer.DataLogic
{
    public class SQLLoginLog
    {
        private static Database db = null;

        private static IRowMapper<LoginLog> GetMapper()
        {
            IRowMapper<LoginLog> mapper = MapBuilder<LoginLog>.MapAllProperties()
                .Map(x => x.Id).ToColumn("Id")
                .Map(x => x.LoginId).ToColumn("LoginId")
                .Map(x => x.Password).ToColumn("Password")
                .Map(x => x.LoginTypeId).ToColumn("LoginTypeId")
                .Map(x => x.IsSuccess).ToColumn("IsSuccess")
                .Map(x => x.IPAddress).ToColumn("IPAddress")
                .Map(x => x.Details).ToColumn("Details")
                .Map(x => x.CreatedDate).ToColumn("CreatedDate")
                .Build();

            return mapper;
        }

        private static Database AddParam(Database db, DbCommand cmd, LoginLog loginLog)
        {
            db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            db.AddInParameter(cmd, "LoginId", DbType.String, loginLog.LoginId);
            db.AddInParameter(cmd, "Password", DbType.String, loginLog.Password);
            db.AddInParameter(cmd, "LoginTypeId", DbType.Int32, loginLog.LoginTypeId);
            db.AddInParameter(cmd, "IsSuccess", DbType.Boolean, loginLog.IsSuccess);
            db.AddInParameter(cmd, "IPAddress", DbType.String, loginLog.IPAddress);
            db.AddInParameter(cmd, "Details", DbType.String, loginLog.Details);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, loginLog.CreatedDate);

            return db;
        }

        public static int Insert(LoginLog loginLog)
        {
            int id = 0;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>("LogDB");
                DbCommand cmd = db.GetStoredProcCommand("LoginLogInsert");

                db = AddParam(db, cmd, loginLog);
                db.ExecuteNonQuery(cmd);

                Object obj = db.GetParameterValue(cmd, "Id");

                if (obj != null)
                {
                    int.TryParse(obj.ToString(), out id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public static List<LoginLog> LoginLogGetAll()
        {
            List<LoginLog> list = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>("LogDB");

                IRowMapper<LoginLog> rowMapper = GetMapper();

                var accessor = db.CreateSprocAccessor<LoginLog>("LoginLogGetAll");
                list = accessor.Execute().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }


            return list;
        }
    }
}
