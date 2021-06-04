using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wjakimszkle.ApplicationServices.API.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string confirmPassword);
    }
}
