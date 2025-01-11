using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryMS         
{
    public class Book         //class for storing properties of a book
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Numof_Copies { get; set; }
        public int Numof_Borrows { get; set; }

        public Book() 
        { 
            Numof_Borrows = 0;
        }

        public Book(int bookId,string isbn,string title,string author,string category,int numof_copies)
        {
            BookId = bookId;
            ISBN = isbn;
            Title = title;
            Author = author;
            Category = category;
            Numof_Copies = numof_copies;
            Numof_Borrows = 0;
        }
    }
}
