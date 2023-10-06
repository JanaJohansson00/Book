using System.Runtime.InteropServices;
using static Book.Program;

namespace Book
{
    internal class Program
    {
        static void Main(string[] args) //Mainmetoden
        {
            Console.WriteLine("Välkommen till ditt bokbiblitok!");

            //Skapar en lista av böckernasom användaren anger.
            List<Book> library = new List<Book>();//Här skapas en lista med böcker med namnet"library". Lagrar info som användaren anger.

            //Skapar en while-loop så att användaren kan lägga in böcker. När användaren svarar nej avslutas loopen.
            while (true)
            {
                Console.WriteLine("Ange bokens titel:");
                String title = Console.ReadLine();

                Console.WriteLine("Ange författarens namn:");
                String author = Console.ReadLine();

                Console.WriteLine("Ange en sammanfattning av boken:");
                String summary = Console.ReadLine();

                //Skapa en bok med informationen användaren angett. 
                Book myBook = new Book(title, author, summary);
                //Böckerna läggs till i biblioteket.
                library.Add(myBook); 

                Console.Clear();
                Console.WriteLine("Boken har lagts till i biblioteket.");

                string userInput;
                while (true) //Loopen används för att fråga användaren om den vill lägga till en bok.
                {
                    Console.WriteLine("Vill du lägga till en ny bok? Ja/Nej");
                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "ja")//Om användaren svarar ja avslutas den inre loopen och hoppar tillbaka till huvudloopen.
                    {
                        Console.Clear();
                        break;

                    }
                    else if (userInput == "nej") 
                    {
                        Console.Clear();
                        PrintLibrary(library);//Svarar användaren nej så visas biblitoket.
                        Console.WriteLine("Välkommen åter!");
                        return; //Programmet avslutas.
                    }
                    else
                    {
                        Console.WriteLine("Du kan endast svara Ja/Nej");

                    }
                }
            }

        }
        
        public class Book // En klass
        {
            //Fields, ligger inuti klassen
            public string Title;
            public string Author;
            public string Summary;

            public Book(string title, string author, string summary) //Constructor
            {
                Title = title;
                Author = author;
                Summary = summary;
            }

            public void BookInfo() //Metoden
            {
                Console.WriteLine($"Title: {Title} \nAuthor: {Author} \nSummary: {Summary}");
            }
        }

        public static void PrintLibrary(List<Book> library) //Används för att skriva ut böckerna i biblioteket.
        {
            Console.WriteLine("Bibliotekets böcker:");
            foreach (var book in library)
            {
                book.BookInfo();
                Console.WriteLine();
            }
        }
    }
}