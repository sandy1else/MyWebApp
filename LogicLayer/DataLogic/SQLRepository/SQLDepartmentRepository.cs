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
    public class SQLDepartmentRepository : IDepartment
    { 
        Database db = null;
          
        public IRowMapper<Department> GetMaper()
        {
            IRowMapper<Department> mapper = MapBuilder<Department>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.Code).ToColumn("Code")
            .Map(x => x.Name).ToColumn("Name") 
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Department Department, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Department.Id);
            }

            db.AddInParameter(cmd, "Code", DbType.String, Department.Code);
            db.AddInParameter(cmd, "Name", DbType.String, Department.Name); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Department.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Department.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Department.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Department.ModifiedDate);

            return db;

        }

        public int Insert(Department Department)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("DepartmentInsert");

                db = AddParam(db, cmd, Department, isInsert);
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

        public bool Update(Department Department)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("DepartmentUpdate");

                db = AddParam(db, cmd, Department, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("DepartmentDeleteById");

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

        public Department GetById(int? id)
        {
            Department Department = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Department> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Department>("DepartmentGetById");
                Department = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Department;
        }

        public List<Department> GetAll()
        {
            List<Department> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Department> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Department>("DepartmentGetAll");
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
