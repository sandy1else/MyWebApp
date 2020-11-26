using LogicLayer.BusinessObject;
using LogicLayer.DataLogic.IRepository;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.SQLRepository
{
    public class SQLSessionTypeRepository : ISessionType
    {
        public string sqlGetByLoginId = "SessionTypeGetByLoginId";
        Database db = null;
          
        public IRowMapper<SessionType> GetMaper()
        {
            IRowMapper<SessionType> mapper = MapBuilder<SessionType>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.Code).ToColumn("Code") 
            .Map(x => x.Name).ToColumn("Name")
            .Map(x => x.StartDate).ToColumn("StartDate")
            .Map(x => x.EndDate).ToColumn("EndDate") 
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, SessionType SessionType, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, SessionType.Id);
            }

            db.AddInParameter(cmd, "Code", DbType.String, SessionType.Code);
            db.AddInParameter(cmd, "Name", DbType.String, SessionType.Name);
            db.AddInParameter(cmd, "StartDate", DbType.Date, SessionType.StartDate);
            db.AddInParameter(cmd, "EndDate", DbType.Date, SessionType.EndDate); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, SessionType.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, SessionType.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, SessionType.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, SessionType.ModifiedDate);

            return db;

        }

        public int Insert(SessionType SessionType)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("TypeInsertSession");

                db = AddParam(db, cmd, SessionType, isInsert);
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

        public bool Update(SessionType SessionType)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("SessionTypeUpdate");

                db = AddParam(db, cmd, SessionType, isInsert);
                int rowAffected = db.ExecuteNonQuery(cmd);

                if (rowAffected > 0)
                {
                    isUpate = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isUpate;
        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("SessionTypeDeleteById");

                db.AddInParameter(cmd, "Id", DbType.Int32, id);
                int rowAffected = db.ExecuteNonQuery(cmd);

                if (rowAffected > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public SessionType GetById(int? id)
        {
            SessionType SessionType = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<SessionType> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<SessionType>("SessionTypeGetById");
                SessionType = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return SessionType;
        }

        public List<SessionType> GetAll()
        {
            List<SessionType> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<SessionType> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<SessionType>("SessionTypeGetAll");
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
