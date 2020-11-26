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
    public class SQLPersonRepository : IPerson
    {
        public string sqlGetByLoginId = "PersonGetByLoginId";
        Database db = null;
         
        public IRowMapper<Person> GetMaper()
        {
            IRowMapper<Person> mapper = MapBuilder<Person>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.GenderId).ToColumn("GenderId")
            .Map(x => x.ReligionId).ToColumn("ReligionId")
            .Map(x => x.Name).ToColumn("Name")
            .Map(x => x.Address).ToColumn("Address")
            .Map(x => x.ContactNo).ToColumn("ContactNo")
            .Map(x => x.EmailAddress).ToColumn("EmailAddress")
            .Map(x => x.DOB).ToColumn("DOB")
            .Map(x => x.PhotoURL).ToColumn("PhotoURL")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Person Person, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Person.Id);
            }

            db.AddInParameter(cmd, "GenderId", DbType.Int32, Person.GenderId);
            db.AddInParameter(cmd, "ReligionId", DbType.Int32, Person.ReligionId);
            db.AddInParameter(cmd, "Name", DbType.String, Person.Name);
            db.AddInParameter(cmd, "Address", DbType.String, Person.Address);
            db.AddInParameter(cmd, "NID", DbType.String, Person.NID);
            db.AddInParameter(cmd, "ContactNo", DbType.String, Person.ContactNo);
            db.AddInParameter(cmd, "EmailAddress", DbType.String, Person.EmailAddress);
            db.AddInParameter(cmd, "DOB", DbType.Date, Person.DOB);
            db.AddInParameter(cmd, "PhotoURL", DbType.String, Person.PhotoURL);
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Person.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Person.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Person.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Person.ModifiedDate);

            return db;

        }

        public int Insert(Person Person)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("PersonInsert");

                db = AddParam(db, cmd, Person, isInsert);
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

        public bool Update(Person Person)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("PersonUpdate");

                db = AddParam(db, cmd, Person, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("PersonDeleteById");

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

        public Person GetById(int? id)
        {
            Person Person = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Person> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Person>("PersonGetById");
                Person = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Person;
        }

        public List<Person> GetAll()
        {
            List<Person> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Person> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Person>("PersonGetAll");
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
