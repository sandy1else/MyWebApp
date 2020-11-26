using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IGender
    {
        int Insert(Gender Gender);
        bool Update(Gender Gender);
        bool Delete(int id);
        Gender GetById(int? id);
        List<Gender> GetAll(); 

    }
}
