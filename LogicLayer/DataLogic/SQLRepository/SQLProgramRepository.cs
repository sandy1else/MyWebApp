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
    public class SQLProgramRepository : IProgram
    {
        public string sqlGetByLoginId = "ProgramGetByLoginId";
        Database db = null;
          
        public IRowMapper<Program> GetMaper()
        {
            IRowMapper<Program> mapper = MapBuilder<Program>.MapNoProperties()
            .Map(x => x.Id).ToColumn("Id")
            .Map(x => x.Code).ToColumn("Code")
            .Map(x => x.Name).ToColumn("Name")
            .Map(x => x.DeptId).ToColumn("DeptId")
            .Map(x => x.Duration).ToColumn("Duration")
            .Map(x => x.TotalCredit).ToColumn("TotalCredit")
            .Map(x => x.CreatedBy).ToColumn("CreatedBy")
            .Map(x => x.CreatedDate).ToColumn("CreatedDate")
            .Map(x => x.ModifiedBy).ToColumn("ModifiedBy")
            .Map(x => x.ModifiedDate).ToColumn("ModifiedDate")
            .Build();

            return mapper;
        }

        private Database AddParam(Database db, DbCommand cmd, Program Program, bool isInsert)
        {
            if (isInsert)
            {
                db.AddOutParameter(cmd, "Id", DbType.Int32, Int32.MaxValue);
            }
            else
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, Program.Id);
            }

            db.AddInParameter(cmd, "Code", DbType.String, Program.Code);
            db.AddInParameter(cmd, "Name", DbType.String, Program.Name);
            db.AddInParameter(cmd, "DeptId", DbType.Int32, Program.DeptId);
            db.AddInParameter(cmd, "Duration", DbType.Int32, Program.Duration);
            db.AddInParameter(cmd, "TotalCredit", DbType.Int32, Program.TotalCredit);
            db.AddInParameter(cmd, "CreatedBy", DbType.Int32, Program.CreatedBy);
            db.AddInParameter(cmd, "CreatedDate", DbType.DateTime, Program.CreatedDate);
            db.AddInParameter(cmd, "ModifiedBy", DbType.Int32, Program.ModifiedBy);
            db.AddInParameter(cmd, "ModifiedDate", DbType.DateTime, Program.ModifiedDate);

            return db;

        }

        public int Insert(Program Program)
        {
            int id = 0;
            bool isInsert = true;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("ProgramInsert");

                db = AddParam(db, cmd, Program, isInsert);
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

        public bool Update(Program Program)
        {
            bool isInsert = false;
            bool isUpate = false;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
                DbCommand cmd = db.GetStoredProcCommand("ProgramUpdate");

                db = AddParam(db, cmd, Program, isInsert);
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
                DbCommand cmd = db.GetStoredProcCommand("ProgramDeleteById");

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

        public Program GetById(int? id)
        {
            Program Program = null;
            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Program> rowMapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Program>("ProgramGetById");
                Program = accessor.Execute(id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }

            return Program;
        }

        public List<Program> GetAll()
        {
            List<Program> list = null;

            try
            {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

                IRowMapper<Program> mapper = GetMaper();

                var accessor = db.CreateSprocAccessor<Program>("ProgramGetAll");
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
