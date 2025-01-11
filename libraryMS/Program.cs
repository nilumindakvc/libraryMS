
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


        Book NewBook = Service.CreateBook();         //adding books from the console
        BooksStore.Add(NewBook);



    }
}