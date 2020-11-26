using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IRoleMenu
    {
        int Insert(RoleMenu RoleMenu);
        bool Update(RoleMenu RoleMenu);
        bool Delete(int id);
        RoleMenu GetById(int? id);
        List<RoleMenu> GetAll(); 

    }
}
