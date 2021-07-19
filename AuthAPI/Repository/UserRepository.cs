using AuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AuthAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext db;

        public UserRepository(UserDbContext _db)
        {
            db = _db;
        }
        public User Login(User user)
        {
            return db.Users.Find(x => x.UserId == user.UserId && x.Password == user.Password).FirstOrDefault();
        }

        public void Register(User user)
        {
            db.Users.InsertOne(user);
        }
    }
}
