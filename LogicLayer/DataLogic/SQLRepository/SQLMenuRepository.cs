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
    public class SQLMenuRepository : IMenu
    {
        public string sqlGetByLoginId = "MenuGetByLoginId";
        Database db = null;
          
        public IRowMapper<Menu> GetMaper()
        {
            IRowMapper<Menu> mapper = MapBuilder<Menu>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.Name).ToColumn("Name")
            .Map(x => x.ParentId).ToColumn("ParentId")
            .Map(x => x.URL).ToColumn("URL") 
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Menu Menu, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Menu.Id);
            }

            db.AddInParameter(cmd, "Name", DbType.String, Menu.Name);
            db.AddInParameter(cmd, "ParentId", DbType.Int32, Menu.ParentId);
            db.AddInParameter(cmd, "URL", DbType.String, Menu.URL); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Menu.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Menu.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Menu.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Menu.ModifiedDate);

            return db;

        }

        public int Insert(Menu Menu)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("MenuInsert");

                db = AddParam(db, cmd, Menu, isInsert);
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

        public bool Update(Menu Menu)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("MenuUpdate");

                db = AddParam(db, cmd, Menu, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("MenuDeleteById");

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

        public Menu GetById(int? id)
        {
            Menu Menu = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Menu> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Menu>("MenuGetById");
                Menu = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Menu;
        }

        public List<Menu> GetAll()
        {
            List<Menu> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Menu> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Menu>("MenuGetAll");
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
