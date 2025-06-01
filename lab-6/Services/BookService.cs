using lab_6.Models;
using lab_6.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public void AddBook(string title, string author, int year)
        {
            var book = new Book { Title = title, Author = author, Year = year, IsAvailable = true };
            _bookRepository.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }
        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
        public List<Book> SearchBooks(string searchTerm)
        {
            var books = _bookRepository.GetAll();
            searchTerm = searchTerm?.ToLower() ?? "";
            return books.Where(b =>
                b.Title.ToLower().Contains(searchTerm) ||
                b.Author.ToLower().Contains(searchTerm)).ToList();
        }
        public void UpdateBook(Book book)
        {
            var books = _bookRepository.GetAll();
            var existing = books.FirstOrDefault(b => b.Id == book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.IsAvailable = book.IsAvailable;
                _bookRepository.SaveAll(books);
            }
        }
    }
}

