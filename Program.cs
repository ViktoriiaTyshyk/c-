using System;

interface ILibraryItem
{
    void BorrowItem();
    void ReturnItem();
    bool CheckAvailability();
}

delegate void BookDelegate();
class Book : ILibraryItem
{
    private string title;
    private string author;
    private int year;
    private bool IsAvailable;
    public Book(string title, string author, int year, bool isAvailable)
    {
        this.title = title;
        this.author = author;
        this.year = year;
        this.IsAvailable = isAvailable;
    }
    public void BorrowItem()
    {
        Console.WriteLine($"The book '{title}' by {author} borrowed successfully.");
    }

    public void ReturnItem()
    {
        Console.WriteLine($"The book '{title}' by {author} returned successfully.");
    }

    public bool CheckAvailability()
    {
        if (IsAvailable) 
        { 
            return true;
        }
        return false;
    }
}

class LibraryUser
{
    protected string name;
    protected int id;

    public LibraryUser(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}

class Student : LibraryUser
{
    private string faculty;
    public Student(string name, int id, string faculty) : base(name, id) 
    { 
        this.faculty= faculty;
    }
}

class Teacher : LibraryUser
{
    private string department;
    public Teacher(string name, int id, string department) : base(name, id) 
    {
        this.department = department;
    }
}

class LibraryException : Exception
{
    public LibraryException(string message) : base(message) { }
}

class Program
{

    static void Main(string[] args)
    {
        Book book = new Book("C# Programming", "John Doe", 2022, true);
        Student student = new Student("Viktoriia Tyshyk", 12, "Prykladna");

        BookDelegate borrowDelegate = () => book.BorrowItem();
        BookDelegate returnDelegate = () => book.ReturnItem();
        borrowDelegate();
        returnDelegate();

        BookDelegate borrowedEventHandler = () => Console.WriteLine("Book status changed: Borrowed");
       // book.BorrowItem += borrowedEventHandler;


        try
        {
            book.BorrowItem();
        }
        catch (LibraryException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        try
        {
            book.ReturnItem();
        }
        catch (LibraryException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


}

