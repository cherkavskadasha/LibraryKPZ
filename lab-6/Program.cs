using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using lab_6.Services;

namespace lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("Лабораторна робота 6, Тема: Електронна бібліотека\nВиконала Черкавська Д.В., група ВТ-23-2\n");

            var bookService = new BookService();
            var userService = new UserService();
            var loanService = new LoanService();

            while (true)
            {
                Console.WriteLine("--- Електронна бібліотека ---");
                Console.WriteLine("1. Додати книгу");
                Console.WriteLine("2. Список книг");
                Console.WriteLine("3. Додати користувача");
                Console.WriteLine("4. Список користувачів");
                Console.WriteLine("5. Видати книгу");
                Console.WriteLine("6. Список виданих книг");
                Console.WriteLine("8. Видалити користувача");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть опцію: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Назва книги: ");
                        var title = Console.ReadLine();
                        Console.Write("Автор: ");
                        var author = Console.ReadLine();
                        bookService.AddBook(title, author);
                        break;
                    case "2":
                        var books = bookService.GetAllBooks();
                        foreach (var book in books)
                            Console.WriteLine($"[{book.Id}] {book.Title} - {book.Author}");
                        break;
                    case "3":
                        Console.Write("Ім’я користувача: ");
                        var name = Console.ReadLine();
                        userService.AddUser(name);
                        break;
                    case "4":
                        var users = userService.GetAllUsers();
                        foreach (var user in users)
                            Console.WriteLine($"[{user.Id}] {user.Name}");
                        break;
                    case "5":
                        Console.Write("ID користувача: ");
                        int userId = int.Parse(Console.ReadLine());
                        Console.Write("ID книги: ");
                        int bookId = int.Parse(Console.ReadLine());
                        loanService.LoanBook(userId, bookId);
                        break;
                    case "6":
                        var loans = loanService.GetAllLoans();
                        foreach (var loan in loans)
                            Console.WriteLine($"Користувач {loan.UserId} → Книга {loan.BookId} (дата: {loan.Date.ToShortDateString()})");
                        break;
                    case "8":
                        Console.Write("ID користувача для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteUserId))
                        {
                            userService.DeleteUser(deleteUserId);
                            Console.WriteLine("Користувача видалено.");
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат ID.");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірна опція.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
