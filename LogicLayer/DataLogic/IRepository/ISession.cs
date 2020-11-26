using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface ISession
    {
        int Insert(Session Session);
        bool Update(Session Session);
        bool Delete(int id);
        Session GetById(int? id);
        List<Session> GetAll(); 

    }
}
