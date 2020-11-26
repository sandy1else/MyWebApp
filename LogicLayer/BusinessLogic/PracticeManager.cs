using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessLogic
{
    public class PracticeManager
    {

        public int EvenNumber { get; set; }
        public static bool IsEvenNumber(int number)
        {
            if (number == 1)
            {
                return false;
            }
            throw new NotImplementedException("Not fully implemented.");
        }
    }

}
