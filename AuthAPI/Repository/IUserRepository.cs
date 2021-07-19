using AuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Repository
{
    public interface IUserRepository
    {
        void Register(User user);
        User Login(User user);
    }
}
