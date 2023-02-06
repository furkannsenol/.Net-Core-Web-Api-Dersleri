using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserManagement.API.Fake;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100);

        [HttpGet] //http://localhost:31874/api/users
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]// http://localhost:31874/api/users/1
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(item => item.Id == id);
            return user;
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(item => item.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Adress = user.Adress;

            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(item => item.Id == id);
            _users.Remove(deletedUser); 
        }
    }
}
