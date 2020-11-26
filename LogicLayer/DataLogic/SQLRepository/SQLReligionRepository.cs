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
    public class SQLReligionRepository : IReligion
    {
        public string sqlGetByLoginId = "ReligionGetByLoginId";
        Database db = null;
          
        public IRowMapper<Religion> GetMaper()
        {
            IRowMapper<Religion> mapper = MapBuilder<Religion>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.ReligionName).ToColumn("ReligionName") 
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Religion Religion, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Religion.Id);
            }

            db.AddInParameter(cmd, "ReligionName", DbType.String, Religion.ReligionName); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Religion.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Religion.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Religion.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Religion.ModifiedDate);

            return db;

        }

        public int Insert(Religion Religion)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("ReligionInsert");

                db = AddParam(db, cmd, Religion, isInsert);
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

        public bool Update(Religion Religion)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("ReligionUpdate");

                db = AddParam(db, cmd, Religion, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("ReligionDeleteById");

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

        public Religion GetById(int? id)
        {
            Religion Religion = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Religion> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Religion>("ReligionGetById");
                Religion = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Religion;
        }

        public List<Religion> GetAll()
        {
            List<Religion> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Religion> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Religion>("ReligionGetAll");
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
