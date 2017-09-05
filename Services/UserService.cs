using System;
using AspNetCore_Stack.Entities;
using AspNetCore_Stack.Repositories;
using AspNetCore_Stack.Utils;

namespace AspNetCore_Stack.Services
{
    public class UserService : BaseService
    {
        private readonly Repository<User> _userRepository;
        
        public UserService()
        {
            _userRepository = new Repository<User>(_db);
        }
        
        public string Register(string username, string password)
        {
            if (IsUsernameExists(username))
            {
                throw new Exception("Username already in use");
            }

            var user = new User
            {
                Username = username,
                Password = password
            };
            
            _userRepository.Add(user);

            return GiveToken(user);
        }
        
        public string Login(string username, string password)
        {

            var user = IsUserExists(username, password);

            if (user == null)
            {
                throw new Exception("Wrong username or password");
            }

            return GiveToken(user);
        }
        
        private User IsUserExists(string username, string password)
        {
            return _userRepository.Get(r => r.Username == username && r.Password == (password));
        }
        
        private bool IsUsernameExists(string username)
        {
            return _userRepository.Get(r => r.Username == username) != null;
        }

        private string GiveToken(User user)
        {
            var token = new UserToken
            {
                UserId = user.Id,
                TokenValue = StringUtils.RandomString()
            };

            _db.UserTokens.Add(token);
            _db.SaveChanges();
            
            return token.TokenValue;
        }

        // not used for now
        private static string HashPassword(string password)
        {
            return StringUtils.Sha256(password);
        }
        
        public void ChangePassword(int userId, string password, string oldPassword)
        {
            var user = GetFreshUser(userId);

            if (user.Password != (oldPassword))
            {
                throw new Exception("Old password is wrong");
            }

            user.Password = password;
            _userRepository.Update(user);
        }
    }
}