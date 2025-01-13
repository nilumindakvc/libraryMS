using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace libraryMS
{
    public  static class Service
    {
        public static Book CreateBook()// a function, get inputs through the console,return those with book object
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
        //Insertion sort deneth
        // Edit Start: Fixed sorting logic to correctly alphabetically sort the members by UserName in a case-insensitive way.
        public static void SortMembersByName(DynamicArray<Member> MemberStore)
        {
            // 1. Create a copy of the members
            Member[] members = new Member[MemberStore.count];
            for (int i = 0; i < MemberStore.count; i++)
            {
                members[i] = MemberStore.GetObj(i);
            }

            // 2. Sort the members array using Insertion Sort
            for (int i = 1; i < members.Length; i++)
            {
                Member key = members[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(members[j].UserName, key.UserName) > 0)
                {
                    members[j + 1] = members[j];
                    j--;
                }

                members[j + 1] = key;
            }

            // 3. Clear and update the MemberStore
            MemberStore.count = 0;
            foreach (var member in members)
            {
                MemberStore.Add(member);
            }
        
        }
        // Edit End
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


        public static void BorrowBook( DynamicArray<Book> bookStore)
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

            
                for (int i = 0; i < bookStore.count; i++)
                {
                    Book book = bookStore.GetObj(i);
                    if (book.Category == category)
                    {
                        Console.WriteLine(book.Title +"(id:"+ book.BookId+")");
                    }
                }


        }
        





    }
}
