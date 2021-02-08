using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    public interface ICRUD<T>
    {
        int Insert(T Entity); 
        bool Update(T Person);
        bool Delete(int id);
        T GetById(int? id);
        List<T> GetAll();

    }
}
