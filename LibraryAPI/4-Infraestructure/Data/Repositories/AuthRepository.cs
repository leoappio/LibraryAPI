using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._4_Infraestructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        //Aqui eu fiz hard code o cadastro dos usuários para simplificar
        //porém, se quisesse adicionar os dados em um banco, bastaria substituir o corpo deste metodo para um select
        public User GetUser(string email, string password)
        {
            var users = new List<User>
            {
                new User{Email = "admin@mail.com", Password = "admin"},
                new User{Email = "user@mail.com", Password = "user"}
            };

            return users.FirstOrDefault(
                x => x.Email == email
                && x.Password == password);
        }
    }
}
