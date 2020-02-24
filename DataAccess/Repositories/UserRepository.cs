using DataAccess.DbModels;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly FutbikDbContext _db;

        public UserRepository(FutbikDbContext db)
        {
            _db = db;
        }

        public UserDto GetAuthData(UserDto user)
        {
            User userDb = null;
            if(user.UserId != null)
            {
                userDb = _db.User.Find(user.UserId.Value);                
            } 
            else
            {
                userDb = _db.User.FirstOrDefault(p => p.Phone == user.Phone);
                if(userDb == null)
                {
                    userDb = new User { 
                        Name = user.Name,
                        Phone = user.Phone,
                        PkUser = Guid.NewGuid()
                    };
                }
            }

            return new UserDto
            {
                Name = userDb.Name,
                Phone = userDb.Phone,
                UserId = userDb.PkUser
            }; 
        }
    }
}
