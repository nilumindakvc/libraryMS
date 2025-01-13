using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryMS
{
    public static class Service
    {
        public static Book CreateBook()                  // a function, get inputs through the console,return those with book object
        {
            Book book = new Book();

            Console.Write("Book Id: ");
            book.BookId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Title: ");
            book.Title = Console.ReadLine();

            Console.Write("ISBN: ");
            book.ISBN = Console.ReadLine();

            Console.Write("Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Category: ");
            book.Category = Console.ReadLine();

            Console.Write("NumofCopies: ");
            book.Numof_Copies = Convert.ToInt32(Console.ReadLine());

            book.Numof_Borrows = 0;

            book.WaitingQueue = new Queue<string>();  //she 

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
        public static OutgoneBook CreateOutgoneBook(string BookName, int BookId, string BorrowerId)
        {
            OutgoneBook Outgone_book = new OutgoneBook();

            Outgone_book.Title = BookName;
            Outgone_book.BookId = BookId;
            Outgone_book.MemberId = BorrowerId;
            Outgone_book.OutGoneDate = DateTime.Now;



            return Outgone_book;
        }

        public static void ReadMember(DynamicArray<Member> MemberStore, string user_id)
        {

            // linear serch is implemented here

            for (int i = 0; i < MemberStore.count; i++)
            {
                Member reading_member = MemberStore.GetObj(i);
                if (reading_member.UserId == user_id)
                {
                    Console.WriteLine("Member Name    : " + reading_member.UserName);
                    Console.WriteLine("Member Email   : " + reading_member.Email);
                    Console.WriteLine("registered Day : " + reading_member.RegisteredDay.ToShortDateString());
                    break;
                }

            }
        }


        public static void BorrowBook(DynamicArray<Book> bookStore, DynamicArray<OutgoneBook> outgoneBooks)
        {
            Console.WriteLine(
                "Available Categories" +
                "\nMathematics         -->M" +
                "\nPhysics             -->P" +
                "\nChemistry           -->C" +
                "\nEconomics           -->E" +
                "\nComputer Science    -->Cs" +
                "\nBiology             -->B" +
                "\nBusiness            -->Bs"
            );

            bool MemberIdEntered = false;
            int FurtherBooks = 1;
            string borrower_id = " ";
            int bookid_or_exit = 1;

            do
            {

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
                        Console.WriteLine(book.Title + "(id:" + book.BookId + ")");
                        BookBucket.Add(book);
                    }
                }





                Console.Write("\nenter book id or exit by 0 : ");
                bookid_or_exit = Convert.ToInt32(Console.ReadLine());

                if (bookid_or_exit != 0)
                {

                    for (int i = 0; i < BookBucket.count; i++)
                    {
                        Book book = BookBucket.GetObj(i);
                        if (bookid_or_exit == book.BookId)
                        {
                            if (book.Numof_Copies == 0)  //begin she
                            { // add user to the waiting queue if no available copies    
                                Console.WriteLine("\nNo copies are available");
                                Console.Write("Enter your Member ID to join the waiting list: ");
                                string memberId = Console.ReadLine();

                                book.WaitingQueue.Enqueue(memberId);
                                Console.WriteLine($"You have been added to the waiting list for '{book.Title}'. \nPosition in queue: {book.WaitingQueue.Count}");
                            }
                            // end she  

                            else
                            {
                                if (MemberIdEntered == false)
                                {
                                    Console.Write("enter your MemberId: ");
                                    borrower_id = Console.ReadLine();
                                    MemberIdEntered = true;
                                }

                                OutgoneBook outedBook = CreateOutgoneBook(book.Title, book.BookId, borrower_id);
                                outgoneBooks.Add(outedBook);

                                Console.WriteLine("\nBook name :" + book.Title + " is borrowed ");
                                book.Numof_Copies -= 1;
                                Console.WriteLine("remain copies: " + book.Numof_Copies);

                                Console.Write("for more books enter 1 or exit by 0: ");
                                FurtherBooks = Convert.ToInt32(Console.ReadLine());

                            }

                        }

                    }
                }
            } while (FurtherBooks != 0 && bookid_or_exit != 0);
        }
        //  begin she
        public static void DisplayWaitingQueue(DynamicArray<Book> bookStore)    
        {
            Console.Write("Enter the book ID to view the waiting queue: ");
            int bookId = Convert.ToInt32(Console.ReadLine());

            // Linear search to find the book
            Book book = null;
            for (int i = 0; i < bookStore.count; i++)
            {
                if (bookStore.GetObj(i).BookId == bookId)
                {
                    book = bookStore.GetObj(i);
                    break;
                }
            }

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (book.WaitingQueue.Count == 0)
            {
                Console.WriteLine($"No one is in the waiting queue for '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"Waiting queue for '{book.Title}':");
                foreach (var memberId in book.WaitingQueue)
                {
                    Console.WriteLine($"- {memberId}");
                }
            }
        }
        // end she




        public static void ReadOutgoneBooks(DynamicArray<OutgoneBook> outsideBooks)
        {
            if (outsideBooks.count == 0)
            {
                Console.WriteLine("no book gone out side");
            }
            else
            {
                for (int i = 0; i < outsideBooks.count; i++)
                {
                    OutgoneBook book = outsideBooks.GetObj(i);
                    Console.WriteLine("book id: " + book.BookId + "\t" +
                                                  book.Title + "\tborrowed by member id: " +
                                                  book.MemberId + "\tdate: " +
                                                  book.OutGoneDate.ToString()

                    );
                }
            }
        }


        public static void SortOutgoneBooksByDate(DynamicArray<OutgoneBook> outgonebooks)
        {
            if (outgonebooks.count == 0)
            {
                Console.WriteLine("no book gone out to sort");
                return;
            }

            Console.WriteLine("\noldest  bookout to top --> ofst" +
                               "\nnewest bookout to top  --> nfst");
            Console.Write("\nenter the order: ");
            string user_input = Console.ReadLine();

            int n = outgonebooks.count;

            if (user_input == "ofst")
            {

                for (int i = 0; i < n - 1; i++)                                 //bubble sort for accending order sorting
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        OutgoneBook book1 = outgonebooks.GetObj(j);
                        OutgoneBook book2 = outgonebooks.GetObj(j + 1);

                        if (book1.OutGoneDate > book2.OutGoneDate)
                        {
                            // Swap two outgonebook objects

                            OutgoneBook temp = new OutgoneBook();

                            temp.BookId = book1.BookId;
                            temp.Title = book1.Title;
                            temp.MemberId = book1.MemberId;
                            temp.OutGoneDate = book1.OutGoneDate;

                            book1.BookId = book2.BookId;
                            book1.Title = book2.Title;
                            book1.MemberId = book2.MemberId;
                            book1.OutGoneDate = book2.OutGoneDate;

                            book2.BookId = temp.BookId;
                            book2.Title = temp.Title;
                            book2.MemberId = temp.MemberId;
                            book2.OutGoneDate = temp.OutGoneDate;

                        }
                    }
                }
                Console.WriteLine("sorted");
            }
            else
            {

                for (int i = 0; i < n - 1; i++)                                 //bubble sort for deccending  order sorting
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        OutgoneBook book1 = outgonebooks.GetObj(j);
                        OutgoneBook book2 = outgonebooks.GetObj(j + 1);

                        if (book1.OutGoneDate < book2.OutGoneDate)
                        {
                            // Swap two outgonebook objects

                            OutgoneBook temp = new OutgoneBook();

                            temp.BookId = book1.BookId;
                            temp.Title = book1.Title;
                            temp.MemberId = book1.MemberId;
                            temp.OutGoneDate = book1.OutGoneDate;

                            book1.BookId = book2.BookId;
                            book1.Title = book2.Title;
                            book1.MemberId = book2.MemberId;
                            book1.OutGoneDate = book2.OutGoneDate;

                            book2.BookId = temp.BookId;
                            book2.Title = temp.Title;
                            book2.MemberId = temp.MemberId;
                            book2.OutGoneDate = temp.OutGoneDate;

                        }
                    }
                }
                Console.WriteLine("sorted");
            }

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

            Console.WriteLine("sorted");

        }

        public static void ReadAllMembers(DynamicArray<Member> MemberStore)
        {
            Console.WriteLine("\nMember List:\n");
            for (int i = 0; i < LibraryManager.MemberStore.count; i++)
            {
                Member member = LibraryManager.MemberStore.GetObj(i);  // Fetch the sorted member
                Console.WriteLine(member.UserId + "\t" + member.UserName);  // Display sorted member info
            }
        }
    }
}

