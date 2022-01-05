using LibraryAPI._3_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface IAuthRepository
    {
        public User GetUser(string email, string password);
    }
}
