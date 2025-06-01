using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using lab_6.Utils;
namespace lab_6.Repositories
{
    public class UserRepository
    {
        private const string FilePath = "users.json";

        public List<User> GetAll() => FileHelper.Load<List<User>>(FilePath) ?? new List<User>();

        public void SaveAll(List<User> users) => FileHelper.Save(FilePath, users);

        public void Add(User user)
        {
            var users = GetAll();
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            SaveAll(users);
        }
    }
}
