using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLayer.BusinessObject
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageURL { get; set; }
        public string ActionName { get; set; }
        public string ActionDetails { get; set; }
        public string CreatedDate { get; set; }
    }
}
