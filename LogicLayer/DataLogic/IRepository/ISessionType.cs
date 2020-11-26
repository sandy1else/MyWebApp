using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface ISessionType
    {
        int Insert(SessionType SessionType);
        bool Update(SessionType SessionType);
        bool Delete(int id);
        SessionType GetById(int? id);
        List<SessionType> GetAll(); 

    }
}
