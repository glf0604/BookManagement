using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Entity classes that represent the book category
    /// </summary>

    public class BookType
    {
        public int TypeId { get; set; }   //Type Id 
        public string TypeName { get; set; }  //Type Name
        public int ParentTypeId { get; set; }  // Parent Type Id
        public string DESC { get; set; }  //Type description
    }
}
