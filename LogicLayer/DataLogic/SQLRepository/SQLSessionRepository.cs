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
    public class SQLSessionRepository : ISession
    {
        public string sqlGetByLoginId = "SessionGetByLoginId";
        Database db = null;
          
        public IRowMapper<Session> GetMaper()
        {
            IRowMapper<Session> mapper = MapBuilder<Session>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.Code).ToColumn("Code")
            .Map(x => x.SessionTypeId).ToColumn("SessionTypeId")
            .Map(x => x.IsCurrent).ToColumn("IsCurrent")
            .Map(x => x.IsNext).ToColumn("IsNext")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Session Session, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Session.Id);
            }

            db.AddInParameter(cmd, "Code", DbType.String, Session.Code);
            db.AddInParameter(cmd, "SessionTypeId", DbType.Int32, Session.SessionTypeId);
            db.AddInParameter(cmd, "IsCurrent", DbType.Boolean, Session.IsCurrent);
            db.AddInParameter(cmd, "IsNext", DbType.Boolean, Session.IsNext); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Session.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Session.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Session.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Session.ModifiedDate);

            return db;

        }

        public int Insert(Session Session)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("SessionInsert");

                db = AddParam(db, cmd, Session, isInsert);
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

        public bool Update(Session Session)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("SessionUpdate");

                db = AddParam(db, cmd, Session, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("SessionDeleteById");

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

        public Session GetById(int? id)
        {
            Session Session = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Session> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Session>("SessionGetById");
                Session = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Session;
        }

        public List<Session> GetAll()
        {
            List<Session> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Session> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Session>("SessionGetAll");
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
