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
        public static OutgoneBook CreateOutgoneBook(string BookName,int BookId,string BorrowerId)
        {
            OutgoneBook Outgone_book = new OutgoneBook();

            Outgone_book.Title = BookName;
            Outgone_book.BookId=BookId;
            Outgone_book.MemberId=BorrowerId;
            Outgone_book.OutGoneDate=DateTime.Today;
            Outgone_book.OutGoneTime=DateTime.Now.TimeOfDay;


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
                    break;
                }

            }
        }


        public static void BorrowBook( DynamicArray<Book> bookStore,DynamicArray<OutgoneBook> outgoneBooks)
        {
            Console.WriteLine(
                "Available Categories" +
                "\nMathematics         -->M"+
                "\nPhysics             -->P"+
                "\nChemistry           -->C"+
                "\nEconomics           -->E"+
                "\nComputer Science    -->Cs"+
                "\nBiology             -->B"+
                "\nBusiness            -->Bs"
            );

            Console.Write("enter category: ");
            string user_input = Console.ReadLine();

            string category;

            switch (user_input)
            {
                case "M":
                    category = "Mathematics";
                    break;
                case "P":
                    category = "Physics";
                    break;
                case "C":
                    category = "Chemistry";
                    break;
                case "E":
                    category = "Economics";
                    break;
                case "Cs":
                    category = "Computer Science";
                    break;
                case "B":
                    category = "Biology";
                    break;
                case "Bs":
                    category = "Business";
                    break;
                default:
                    category = "invalid";
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("avilable books\n");

            DynamicArray<Book> BookBucket = new DynamicArray<Book>(); //this dynamic array is for seperating some books from bookstore
                
            
                for (int i = 0; i < bookStore.count; i++)   
                {
                    Book book = bookStore.GetObj(i);
                    if (book.Category == category)                  //linear serch going here
                    {
                        Console.WriteLine(book.Title +"(id:"+ book.BookId+")");
                        BookBucket.Add(book);
                    }
                }
            
            Console.Write("\nenter book id or exit by '0' : ") ;
            int bookid_or_exit =Convert.ToInt32( Console.ReadLine());

            if( bookid_or_exit != 0)
            {
                
                for(int i = 0; i < BookBucket.count; i++)
                {
                    Book book = BookBucket.GetObj(i);
                    if (bookid_or_exit == book.BookId)
                    {
                        if(book.Numof_Copies == 0)
                        {
                            Console.WriteLine("\nNo copies are available") ;
                            Console.WriteLine("you will be added to waiting list");
                        }
                        else
                        {
                            Console.Write("enter your MemberId: ") ;
                            string borrower_id = Console.ReadLine();

                            OutgoneBook outedBook = CreateOutgoneBook(book.Title, book.BookId,borrower_id);
                            outgoneBooks.Add(outedBook);

                            Console.WriteLine("\nBook name :" + book.Title + " is borrowed ");
                            book.Numof_Copies -= 1;
                            Console.WriteLine("remain copies: " + book.Numof_Copies);

                        }
                       
                    }
                    
                }
            }
        }
        

        public static void ReadOutgoneBooks(DynamicArray<OutgoneBook> outsideBooks)
        {
            if (outsideBooks.count == 0)
            {
                Console.WriteLine("no book gone out side");
            }
            else
            {
                for(int i = 0;i < outsideBooks.count; i++)
                {
                    OutgoneBook book = outsideBooks.GetObj(i);
                    Console.WriteLine("book id: " + book.BookId + "\t" +
                                                  book.Title + "\tborrowed by member id: " +
                                                  book.MemberId + "\tdate: " +
                                                  book.OutGoneDate.ToString() + "\tat: " +
                                                  book.OutGoneTime.ToString()
                    );
                }
            }
        }
    }
}
