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
    public class SQLGenderRepository : IGender
    { 
        Database db = null;
          
        public IRowMapper<Gender> GetMaper()
        {
            IRowMapper<Gender> mapper = MapBuilder<Gender>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.GenderName).ToColumn("GenderName")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Gender Gender, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Gender.Id);
            }

            db.AddInParameter(cmd, "GenderName", DbType.String, Gender.GenderName); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Gender.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Gender.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Gender.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Gender.ModifiedDate);

            return db;

        }

        public int Insert(Gender Gender)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("GenderInsert");

                db = AddParam(db, cmd, Gender, isInsert);
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

        public bool Update(Gender Gender)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("GenderUpdate");

                db = AddParam(db, cmd, Gender, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("GenderDeleteById");

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

        public Gender GetById(int? id)
        {
            Gender Gender = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Gender> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Gender>("GenderGetById");
                Gender = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Gender;
        }

        public List<Gender> GetAll()
        {
            List<Gender> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Gender> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Gender>("GenderGetAll");
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
