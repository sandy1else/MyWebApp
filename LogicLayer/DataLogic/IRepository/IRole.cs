using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IRole
    {
        int Insert(Role Role);
        bool Update(Role Role);
        bool Delete(int id);
        Role GetById(int? id);
        List<Role> GetAll();  

    }
}
