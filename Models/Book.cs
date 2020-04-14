using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Entity classes that identify book information
    /// </summary>

    public class Book
    {
        public string BookId { get; set; } //Book Id -primary key
        public string BookName { get; set; } //Book name
        public int BookType { get; set; } //Book type
        public string ISBN { get; set; } //ISBN
        public string BookAuthor { get; set; } //Book author 
        public double BookPrice { get; set; } //Book price
        public int BookPress { get; set; } //Book press
        public string BookImage { get; set; } //Book picture
        public DateTime BookPublishDate { get; set; } //Book publish date 
        public int StorageInNum { get; set; } //Store number
        public DateTime StorageInDate { get; set; } //Store in date
        public int InventoryNum { get; set; } //Inventory number
        public int BorrowedNum { get; set; } //Borrowed number
    }
}
