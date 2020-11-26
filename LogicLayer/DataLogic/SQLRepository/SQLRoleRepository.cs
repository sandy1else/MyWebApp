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
    public class SQLRoleRepository : IRole
    {
        public string sqlGetByLoginId = "RoleGetByLoginId";
        Database db = null;
         
        public IRowMapper<Role> GetMaper()
        {
            IRowMapper<Role> mapper = MapBuilder<Role>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.RoleName).ToColumn("RoleName") 
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Role Role, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Role.Id);
            }

            db.AddInParameter(cmd, "RoleName", DbType.String, Role.RoleName); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Role.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Role.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Role.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Role.ModifiedDate);

            return db;

        }

        public int Insert(Role Role)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("RoleInsert");

                db = AddParam(db, cmd, Role, isInsert);
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

        public bool Update(Role Role)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("RoleUpdate");

                db = AddParam(db, cmd, Role, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("RoleDeleteById");

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

        public Role GetById(int? id)
        {
            Role Role = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Role> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Role>("RoleGetById");
                Role = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Role;
        }

        public List<Role> GetAll()
        {
            List<Role> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Role> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Role>("RoleGetAll");
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
