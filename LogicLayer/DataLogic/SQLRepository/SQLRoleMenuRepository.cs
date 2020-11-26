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
    public class SQLRoleMenuRepository : IRoleMenu
    {
        public string sqlGetByLoginId = "RoleMenuGetByLoginId";
        Database db = null;
          
        public IRowMapper<RoleMenu> GetMaper()
        {
            IRowMapper<RoleMenu> mapper = MapBuilder<RoleMenu>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.MenuId).ToColumn("MenuId") 
            .Map(x => x.RoleId).ToColumn("RoleId")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, RoleMenu RoleMenu, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, RoleMenu.Id);
            }
             
            db.AddInParameter(cmd, "MenuId", DbType.Int32, RoleMenu.MenuId);
            db.AddInParameter(cmd, "RoleId", DbType.Int32, RoleMenu.RoleId);
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, RoleMenu.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, RoleMenu.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, RoleMenu.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, RoleMenu.ModifiedDate);

            return db;

        }

        public int Insert(RoleMenu RoleMenu)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("RoleMenuInsert");

                db = AddParam(db, cmd, RoleMenu, isInsert);
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

        public bool Update(RoleMenu RoleMenu)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("RoleMenuUpdate");

                db = AddParam(db, cmd, RoleMenu, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("RoleMenuDeleteById");

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

        public RoleMenu GetById(int? id)
        {
            RoleMenu RoleMenu = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<RoleMenu> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<RoleMenu>("RoleMenuGetById");
                RoleMenu = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return RoleMenu;
        }

        public List<RoleMenu> GetAll()
        {
            List<RoleMenu> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<RoleMenu> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<RoleMenu>("RoleMenuGetAll");
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
