using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// The entity class used to describe member information
    /// </summary>
    public class Member
    {
        public string MemberId { get; set; }  //MemberId
        public string MemberName { get; set; }  //MemberName
        public string MemberCardId { get; set; }  //MemberCardId
        public int MemberLevel { get; set; }  //MemberLevel
        public string IdType { get; set; }  //IdType
        public string IdNumber { get; set; }  //IdNumber
        public string Gender { get; set; }  //Gender
        public string TelNo { get; set; }  //TelNo
        public DateTime Birthday { get; set; }  //Birthday 
        public string HomeAddress { get; set; }  //HomeAddress
        public string MemberPhoto { get; set; }  //MemberPhoto
        public string CardStatus { get; set; }  //CardStatus 
        public DateTime CardClosingDate { get; set; }  //CardClosingDate
        public bool IsReturnDeposit { get; set; }  //IsReturnDeposit
        public string PayMethod { get; set; }  //PayMethod 
        public int LoginId { get; set; }  //LoginId
        public DateTime OperatingTime { get; set; }  //OperatingTime 
        public string ReMarks { get; set; }  //ReMarks
    }
}
