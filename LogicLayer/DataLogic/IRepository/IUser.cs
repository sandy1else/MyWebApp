using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IUser
    {
        int Insert(User User);
        bool Update(User User);
        bool Delete(int id);
        User GetById(int? id);
        List<User> GetAll();
        User UserGetByLoginId(string LoginId); 

    }
}
