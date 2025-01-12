using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryMS
{
    public  static class Service
    {
        public static Book CreateBook()                  // a function, get inputs through the console,return those with book object
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

        public static Member CreateMember()        //take input from console for new member,return those with member obj
        {
            Member member = new Member();

            Console.Write("UserId: ");
            member.UserId = Console.ReadLine();

            Console.Write("User Name: ");
            member.UserName = Console.ReadLine();


            return member;
        }

        //this function will automatically call wahen a member take a book,within a another function
        public static OutgoneBook CreateOutgoneBook(string BookName,string BookId,string Borrower,String BorrowerId)
        {
            OutgoneBook Outgone_book = new OutgoneBook();

            Outgone_book.Title = BookName;
            Outgone_book.BookId=BookId;
            Outgone_book.MemberName=Borrower;
            Outgone_book.MemberId=BorrowerId;


            return Outgone_book;
        }

        public static void  ReadMember(DynamicArray<Member> MemberStore ,string user_id)
        {
             
            // linear serch is implemented here

            for(int i = 0; i < MemberStore.count; i++)
            {
               Member reading_member = MemberStore.GetObj(i);
               if(reading_member.UserId== user_id)
                {
                    Console.WriteLine("Member Name    : "+reading_member.UserName);
                    Console.WriteLine("Member Email   : "+reading_member.Email);
                    Console.WriteLine("registered Day : "+reading_member.RegisteredDay.ToShortDateString());
                }

            }
        }

    }
}
