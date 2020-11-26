using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IProgram
    {
        int Insert(Program Program);
        bool Update(Program Program);
        bool Delete(int id);
        Program GetById(int? id);
        List<Program> GetAll(); 

    }
}
