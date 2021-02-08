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
    public class SQLAcademicSessionRepository : IAcademicSession
    {
        public string sqlGetByLoginId = "AcademicSessionGetByLoginId";
        Database db = null;
          
        public IRowMapper<AcademicSession> GetMaper()
        {
            IRowMapper<AcademicSession> mapper = MapBuilder<AcademicSession>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.Code).ToColumn("Code")
            .Map(x => x.AcademicSessionTypeId).ToColumn("AcademicSessionTypeId")
            .Map(x => x.IsCurrent).ToColumn("IsCurrent")
            .Map(x => x.IsNext).ToColumn("IsNext")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }         

        private Database AddParam(Database db, DbCommand cmd, AcademicSession AcademicSession, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, AcademicSession.Id);
            }

            db.AddInParameter(cmd, "Code", DbType.String, AcademicSession.Code);
            db.AddInParameter(cmd, "AcademicSessionTypeId", DbType.Int32, AcademicSession.AcademicSessionTypeId);
            db.AddInParameter(cmd, "IsCurrent", DbType.Boolean, AcademicSession.IsCurrent);
            db.AddInParameter(cmd, "IsNext", DbType.Boolean, AcademicSession.IsNext); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, AcademicSession.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, AcademicSession.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, AcademicSession.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, AcademicSession.ModifiedDate);

            return db;

        }

        public int Insert(AcademicSession AcademicSession)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("AcademicSessionInsert");

                db = AddParam(db, cmd, AcademicSession, isInsert);
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

        public bool Update(AcademicSession AcademicSession)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("AcademicSessionUpdate");

                db = AddParam(db, cmd, AcademicSession, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("AcademicSessionDeleteById");

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

        public AcademicSession GetById(int? id)
        {
            AcademicSession AcademicSession = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<AcademicSession> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<AcademicSession>("AcademicSessionGetById");
                AcademicSession = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return AcademicSession;
        }

        public List<AcademicSession> GetAll()
        {
            List<AcademicSession> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<AcademicSession> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<AcademicSession>("AcademicSessionGetAll");
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
