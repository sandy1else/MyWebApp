using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IMenu
    {
        int Insert(Menu Menu);
        bool Update(Menu Menu);
        bool Delete(int id);
        Menu GetById(int? id);
        List<Menu> GetAll(); 

    }
}
