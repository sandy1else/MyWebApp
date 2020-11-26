using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IReligion
    {
        int Insert(Religion Religion);
        bool Update(Religion Religion);
        bool Delete(int id);
        Religion GetById(int? id);
        List<Religion> GetAll(); 

    }
}
