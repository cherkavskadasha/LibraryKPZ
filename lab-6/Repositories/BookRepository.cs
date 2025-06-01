using lab_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using lab_6.Utils;

namespace lab_6.Repositories
{
    public class BookRepository
    {
        private const string FilePath = "books.json";

        public List<Book> GetAll() => FileHelper.Load<List<Book>>(FilePath) ?? new List<Book>();

        public void SaveAll(List<Book> books) => FileHelper.Save(FilePath, books);

        public void Add(Book book)
        {
            var books = GetAll();
            book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
            SaveAll(books);
        }
    }
}
