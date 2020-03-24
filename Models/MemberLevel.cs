using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Entity classes that represent membership levels
    /// </summary>
    public class MemberLevel
    {
        public int LevelId { get; set; }  //LevelId
        public string LevelName { get; set; }  //LevelName
        public int LevelMonths { get; set; }  //LevelMonths
        public int MaxBorrowNum { get; set; }  //MaxBorrowNum
        public int MaxBorrowDays { get; set; }  //MaxBorrowDays
        public double Deposit { get; set; }  //Deposit
    }
}
