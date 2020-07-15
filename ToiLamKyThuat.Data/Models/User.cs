using System;
using System.Collections.Generic;

namespace ToiLamKyThuat.Data.Models
{
    public partial class User : BaseModel
    {
        public User()
        {
            Code = Guid.NewGuid().ToString();
        }
        public string Username { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
