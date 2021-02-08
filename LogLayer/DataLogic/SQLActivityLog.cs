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
    public class SQLActivityLog
    {
        private static Database db = null;

        private static IRowMapper<ActivityLog> GetMapper()
        {
            IRowMapper<ActivityLog> mapper = MapBuilder<ActivityLog>.MapAllProperties()
                .Map(x => x.Id).ToColumn("Id")
                .Map(x => x.LoginId).ToColumn("LoginId")
                .Map(x => x.PageId).ToColumn("PageId")
                .Map(x => x.PageName).ToColumn("PageName")
                .Map(x => x.PageURL).ToColumn("PageURL")
                .Map(x => x.ActionName).ToColumn("ActionName")
                .Map(x => x.ActionDetails).ToColumn("ActionDetails")
                .Map(x => x.CreatedDate).ToColumn("CreatedDate")
                .Build();

            return mapper;
        }

        private static Database AddParam(Database db, DbCommand cmd, ActivityLog ActivityLog)
        {
            db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            db.AddInParameter(cmd, "LoginId", DbType.String, ActivityLog.LoginId);
            db.AddInParameter(cmd, "PageId", DbType.String, ActivityLog.PageId);
            db.AddInParameter(cmd, "PageName", DbType.Boolean, ActivityLog.PageName);
            db.AddInParameter(cmd, "PageURL", DbType.Boolean, ActivityLog.PageURL);
            db.AddInParameter(cmd, "ActionName", DbType.String, ActivityLog.ActionName);
            db.AddInParameter(cmd, "ActionDetails", DbType.DateTime, ActivityLog.ActionDetails);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, ActivityLog.CreatedDate);

            return db;
        }

        public static int Insert(ActivityLog ActivityLog)
        {
            int id = 0;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("ActivityLogInsert");

                db = AddParam(db, cmd, ActivityLog);
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

        public static List<ActivityLog> ActivityLogGetAll()
        {
            List<ActivityLog> list = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<ActivityLog> rowMapper = GetMapper();

                var accessor = db.CreateSprocAccessor<ActivityLog>("ActivityLogGetAll");
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
