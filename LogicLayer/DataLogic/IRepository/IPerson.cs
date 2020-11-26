using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IPerson
    {
        int Insert(Person Person);
        bool Update(Person Person);
        bool Delete(int id);
        Person GetById(int? id);
        List<Person> GetAll();  

    }
}
