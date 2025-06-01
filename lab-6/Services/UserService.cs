using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using lab_6.Repositories;

namespace lab_6.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public void AddUser(string name)
        {
            var user = new User { Name = name };
            _userRepo.Add(user);
        }

        public List<User> GetAllUsers() => _userRepo.GetAll();
    }
}
