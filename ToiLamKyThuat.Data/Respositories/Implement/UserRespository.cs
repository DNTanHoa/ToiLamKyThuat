using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToiLamKyThuat.Data.Helpers;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public class UserRespository : Respository<User>, IUserRespository
    {
        private readonly ToiLamKyThuatContext _context;

        public UserRespository(ToiLamKyThuatContext context) : base(context)
        {
            _context = context;
        }

        public bool IsValid(string username, string password)
        {
            var user = _context.User.FirstOrDefault(user => user.Username.Equals(username));
            if(user != null)
            {
                if(SecurityHelper.Decrypt(user.Code,user.Password).Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
