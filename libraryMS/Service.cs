using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryMS
{
    public  static class Service
    {
        public static Book CreateBook()
        {
            Book book = new Book();

            Console.Write("Book Id: ");
            book.BookId = Convert.ToInt32( Console.ReadLine());

            Console.Write("Title: ");
            book.Title = Console.ReadLine();

            Console.Write("ISBN: ");
            book.ISBN = Console.ReadLine();

            Console.Write("Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Category: ");
            book.Category = Console.ReadLine();

            Console.Write("NumofCopies: ");
            book.Numof_Copies=Convert.ToInt32(Console.ReadLine());

            book.Numof_Borrows = 0;

            return book;
        }
    }
}
