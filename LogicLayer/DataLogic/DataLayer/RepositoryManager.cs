using LogicLayer.DataLogic.IRepository;
using LogicLayer.DataLogic.SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.DataLayer
{
    public static class RepositoryManager
    {
        public static SQLDepartmentRepository Department_Repository
        {
            get
            {
                return new SQLDepartmentRepository();
            }
        }
        public static SQLGenderRepository Gender_Repository
        {
            get
            {
                return new SQLGenderRepository();
            }
        }
        public static SQLMenuRepository Menu_Repository
        {
            get
            {
                return new SQLMenuRepository();
            }
        }
        public static SQLPersonRepository Person_Repository
        {
            get
            {
                return new SQLPersonRepository();
            }
        }
        public static SQLProgramRepository Program_Repository
        {
            get
            {
                return new SQLProgramRepository();
            }
        }
        public static SQLReligionRepository Religion_Repository
        {
            get
            {
                return new SQLReligionRepository();
            }
        }
        public static SQLRoleRepository Role_Repository
        {
            get
            {
                return new SQLRoleRepository();
            }
        }
        public static SQLRoleMenuRepository RoleMenu_Repository
        {
            get
            {
                return new SQLRoleMenuRepository();
            }
        }
        public static SQLSessionRepository Session_Repository
        {
            get
            {
                return new SQLSessionRepository();
            }
        }
        public static SQLSessionTypeRepository SessionType_Repository
        {
            get
            {
                return new SQLSessionTypeRepository();
            }
        }
        public static SQLStudentRepository Student_Repository
        {
            get
            {
                return new SQLStudentRepository();
            }
        } 

        public static SQLUserRepository User_Repository
        {
            get
            {
                return new SQLUserRepository();
            }
        }

    }
}
