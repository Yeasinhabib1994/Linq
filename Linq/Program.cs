using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            Console.WriteLine("number of books:");
            var count = books.Count();
            Console.WriteLine(count);

            Console.WriteLine("name of books:");
            foreach (var b in books)
            {
                Console.WriteLine("Title: " + b);
            }

            var cheapBooks = books
                .Where(b => b.Price < 10)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            Console.WriteLine("Cheapbooks:");
            foreach (var b in cheapBooks)
            {
                Console.WriteLine("Title: " + b);
            }

            Console.WriteLine("favourite book:");
            var book = books.Single(b => b.Title == "Solid Mechanics");
            Console.WriteLine(book.Title);

            Console.WriteLine("first book in collection:");
            var firstBook = books.First();
            Console.WriteLine("Title: " + firstBook.Title + ". Price: " + firstBook.Price);

            Console.WriteLine("last book in collection:");
            var lastBook = books.Last();
            Console.WriteLine("Title: " + lastBook.Title + ". Price: " + lastBook.Price);

            Console.WriteLine("books after skipping first three:");
            var remainingBooks = books.Skip(2).Take(2);
            foreach (var b in remainingBooks)
            {
                Console.WriteLine(b.Title);
            }

            Console.WriteLine("max price: ");
            var maxPrice = books.Max(b => b.Price);
            Console.WriteLine(maxPrice);

            Console.WriteLine("min price: ");
            var minPrice = books.Min(b => b.Price);
            Console.WriteLine(minPrice);

            Console.WriteLine("total price: ");
            var totalPrice = books.Sum(b => b.Price);
            Console.WriteLine(totalPrice);
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "Mechanics", Price = 1},
                new Book() {Title = "Machine Design", Price = 3},
                new Book() {Title = "Fluid Machinary", Price = 2},
                new Book() {Title = "Solid Mechanics", Price = 15},
            };
        }
    }
}
