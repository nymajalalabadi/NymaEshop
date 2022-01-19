using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NymaEshop2.Data;
using NymaEshop2.Models;

namespace NymaEshop2.Data.Repository
{
    public interface IUserRepository
    {
        Users GetUserForLogin(string email, string password);

        void AddUser(Users users);

        bool IsExistUserByEmail(string email);

            

    }



    public class UserRepository : IUserRepository
    {

        private MyEshopContext _context;
        public UserRepository(MyEshopContext context)
        {
            _context = context;
        }


        public void AddUser(Users users)
        {
             _context.Add(users);
            _context.SaveChanges();
        }


        public Users GetUserForLogin(string email, string password)
        {
            return _context.users.SingleOrDefault(p => p.Email == email && p.Password == password);
        }


        public bool IsExistUserByEmail(string email)
        {
            return _context.users.Any(i => i.Email == email);
        }
    }
}
