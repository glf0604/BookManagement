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
        public double BookPrice { get; set; } //book price
        public int BookPress { get; set; } //book press
        public string BookImage { get; set; } //book picture
        public DateTime BookPublishDate { get; set; } //book publish date 
        public int StorageInNum { get; set; } //store number
        public DateTime StorageInDate { get; set; } //store in date
        public int InventoryNum { get; set; } //inventory number
        public int BorrowedNum { get; set; } //borrowed number
    }
}
