using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessObject
{
    public class BillHistory : BaseInfo
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
    }
}
