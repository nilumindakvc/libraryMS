
using libraryMS;

class Program
{
    static void Main(string[] args)
    {
        LibraryManager.InitializeBooks();                //initialize some books at the strat ,to the LibraryManager.BooksStore dynamic array

        LibraryManager.InitializeMembers();              //initialize some members at the start,to the LibraryManager.MemberStroe dynamic array

        DynamicArray<OutgoneBook> OutgoneBooks = new DynamicArray<OutgoneBook>();   //dyanamic array to store outgonebooks details



       
        Console.WriteLine("Library Management System");

        Console.WriteLine(
              "Add new book         -->  add  -book\n" +
              "Add new member       -->  add  -mem\n" +
              "Read member          -->  read -mem\n" +
              "Borrow book          -->  bor\n" +
              "Outgone books        -->  outed\n"
        );

        

        string Continuity = "y";

        while (Continuity == "y")
        {
            Console.Write("\noperation: ");
            string Operation_selected = Console.ReadLine();
            Console.WriteLine();

            switch (Operation_selected)
            {
                case "add -book":
                    Book NewBook = Service.CreateBook();         //adding books further from the console
                    LibraryManager.BooksStore.Add(NewBook);
                    break;
                case "add -mem":
                    Member member = Service.CreateMember();     //adding members further from the console
                    LibraryManager.MemberStore.Add(member);
                    break;
                case "read -mem":
                    Console.Write("\nenter member id: ");
                    string member_id= Console.ReadLine();
                    Console.WriteLine();
                    Service.ReadMember(LibraryManager.MemberStore, member_id);
                    break;
                case "bor":
                    Service.BorrowBook(LibraryManager.BooksStore,OutgoneBooks);
                    break;
                case "outed":
                    Service.ReadOutgoneBooks(OutgoneBooks);
                    break;
                default:
                    Console.WriteLine("you have not give proper input");
                    break;

            }

            Console.Write("\nmore operations?: y/n  ");
            Continuity= Console.ReadLine();

        }

    }
}