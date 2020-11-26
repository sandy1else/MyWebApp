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
    public class SQLStudentRepository : IStudent
    {
        public string sqlGetByLoginId = "StudentGetByLoginId";
        Database db = null;
          
        public IRowMapper<Student> GetMaper()
        {
            IRowMapper<Student> mapper = MapBuilder<Student>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.PersonId).ToColumn("PersonId")
            .Map(x => x.BatchId).ToColumn("BatchId")
            .Map(x => x.ProgramId).ToColumn("ProgramId")
            .Map(x => x.Roll).ToColumn("Roll") 
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Student Student, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Student.Id);
            }

            db.AddInParameter(cmd, "PersonId", DbType.Int32, Student.PersonId);
            db.AddInParameter(cmd, "BatchId", DbType.Int32, Student.BatchId);
            db.AddInParameter(cmd, "ProgramId", DbType.Int32, Student.ProgramId);
            db.AddInParameter(cmd, "Roll", DbType.String, Student.Roll); 
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Student.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Student.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Student.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Student.ModifiedDate);

            return db;

        }

        public int Insert(Student Student)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("StudentInsert");

                db = AddParam(db, cmd, Student, isInsert);
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

        public bool Update(Student Student)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("StudentUpdate");

                db = AddParam(db, cmd, Student, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("StudentDeleteById");

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

        public Student GetById(int? id)
        {
            Student Student = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Student> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Student>("StudentGetById");
                Student = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Student;
        }

        public List<Student> GetAll()
        {
            List<Student> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Student> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Student>("StudentGetAll");
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
