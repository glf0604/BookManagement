using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Entity classes For information overview of borrowed books
    /// </summary>
    public class BorrowBook
    {
        public string BorrowId { get; set; }   //BorrowId---Primary Key
        public string MemberId { get; set; }   //Member Id
        public int BorrowedNum { get; set; }   //Borrowed Number
        public int OverdueNum { get; set; }   //Overdue Number
    }
}
