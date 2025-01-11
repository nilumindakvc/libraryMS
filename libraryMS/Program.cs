
using libraryMS;

class Program
{
    static void Main(string[] args)
    {
        DynamicArray<Book> BooksStore = new DynamicArray<Book>();                   //dynamic array to store books details 
        
        DynamicArray<Member> MemberStore = new DynamicArray<Member>();              //dynamic array to store member details

        DynamicArray<OutgoneBook> OutgoneBooks = new DynamicArray<OutgoneBook>();   //dyanamic array to store outgonebooks details



        
        BooksStore.Add(new Book(100, "ISBN100", "Fourier Transform", "Butler", "Mathamatics", 10));   //adding books inside the source code
        BooksStore.Add(new Book(100, "ISBN100", "Fourier Transform", "Butler", "Mathamatics", 10));
        BooksStore.Add(new Book(100, "ISBN100", "Fourier Transform", "Butler", "Mathamatics", 10));
        BooksStore.Add(new Book(100, "ISBN100", "Fourier Transform", "Butler", "Mathamatics", 10));
        BooksStore.Add(new Book(100, "ISBN100", "Fourier Transform", "Butler", "Mathamatics", 10));




       ;

        Console.WriteLine("Library Management System");

        Console.WriteLine(
              "Add new book         -->  add -book\n" +
              "Add new member       -->  add -mem\n" );

        

        string Continuity = "y";

        while (Continuity == "y")
        {
            Console.Write("\noperation: ");
            string Operation_selected = Console.ReadLine();

            switch (Operation_selected)
            {
                case "add -book":
                    Book NewBook = Service.CreateBook();         //adding books from the console
                    BooksStore.Add(NewBook);
                    break;
                case "add -mem":
                    Member member = Service.CreateMember();
                    MemberStore.Add(member);
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