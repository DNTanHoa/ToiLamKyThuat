using System;
using System.Collections.Generic;
using System.Text;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public interface IUserRespository : IRespository<User>
    {
        public bool IsValid(string username, string password);
    }
}
