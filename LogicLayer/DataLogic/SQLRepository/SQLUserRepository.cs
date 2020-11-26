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
    public class SQLUserRepository : IUser
    {
        public string sqlGetByLoginId = "UserGetByLoginId";
        Database db = null;

        public IRowMapper<User> GetMaper()
        {
            IRowMapper<User> mapper = MapBuilder<User>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.LoginId).ToColumn("LoginId")
            .Map(x => x.Password).ToColumn("Password")
            .Map(x => x.PersonId).ToColumn("PersonId")
            .Map(x => x.RoleId).ToColumn("RoleId")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, User User, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, User.Id);
            }

            db.AddInParameter(cmd, "LoginId", DbType.String, User.LoginId);
            db.AddInParameter(cmd, "Password", DbType.String, User.Password);
            db.AddInParameter(cmd, "PersonId", DbType.Int32, User.PersonId);
            db.AddInParameter(cmd, "RoleId", DbType.Int32, User.RoleId);
            db.AddInParameter(cmd, "RoleId", DbType.Int32, User.RoleId);
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, User.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, User.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, User.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, User.ModifiedDate);

            return db;

        }

        public int Insert(User User)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("UserInsert");

                db = AddParam(db, cmd, User, isInsert);
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

        public bool Update(User User)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("UserUpdate");

                db = AddParam(db, cmd, User, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("UserDeleteById");

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

        public User GetById(int? id)
        {
            User user = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<User> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<User>("UserGetById");
                user = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return user;
        }

        public List<User> GetAll()
        {
            List<User> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<User> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<User>("UserGetAll");
                list = accessor.Execute().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return list;
        }

        public User UserGetByLoginId(string LoginId)
        {
            User _user = null;
            try
            {

                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<User> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<User>(sqlGetByLoginId, rowMapper);
                _user = accessor.Execute(LoginId).SingleOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return _user;
        }


    }
}
