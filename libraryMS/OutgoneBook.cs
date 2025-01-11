using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryMS
{
    public class OutgoneBook
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string MemberName { get; set; }
        public string MemberId { get; set; }
        public DateTime OutGoneDate { get; set; }

    }
}
