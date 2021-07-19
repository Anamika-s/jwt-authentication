using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateJWTToken(string userid, string role);
    }
}
