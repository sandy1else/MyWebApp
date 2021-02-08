using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic.IRepository
{
    interface IAcademicSession
    {
        int Insert(AcademicSession AcademicSession);
        bool Update(AcademicSession AcademicSession);
        bool Delete(int id);
        AcademicSession GetById(int? id);
        List<AcademicSession> GetAll(); 

    }
}
