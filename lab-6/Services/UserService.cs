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
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void AddUser(string name)
        {
            var user = new User { Name = name };
            _userRepository.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
        public List<User> SearchUsers(string searchTerm)
        {
            var users = _userRepository.GetAll();
            searchTerm = searchTerm?.ToLower() ?? "";
            return users.Where(u => u.Name.ToLower().Contains(searchTerm)).ToList();
        }

    }
}

