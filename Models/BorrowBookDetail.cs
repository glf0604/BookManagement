using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Entity classes that describe the details of borrowing books
    /// </summary>

    public class BorrowBookDetail
    {
        public int DetailId { get; set; }  //Detail Id
        public string BorrowId { get; set; }  //Borrow Id
        public string BookId { get; set; }  //Book Id
        public DateTime BorrowDate { get; set; }  //Borrow Date
        public DateTime LastReturnDate { get; set; }  //Last Return Date
        public bool IsReturn { get; set; }  //Is Return 
        public bool IsOverdue { get; set; }  //Is Overdue 
        public bool IsLost { get; set; }  //IsLost
        public bool IsHandleOverdueorLost { get; set; }  //Is Handle Overdue or Lost
        public DateTime ReturnDate { get; set; }  //Return Date
    }
}

