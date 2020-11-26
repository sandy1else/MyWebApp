using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IStudent
    {
        int Insert(Student Student);
        bool Update(Student Student);
        bool Delete(int id);
        Student GetById(int? id);
        List<Student> GetAll(); 

    }
}
