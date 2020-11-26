using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IDepartment
    {
        int Insert(Department Department);
        bool Update(Department Department);
        bool Delete(int id);
        Department GetById(int? id);
        List<Department> GetAll(); 

    }
}
