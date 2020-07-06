using System;
using System.Collections.Generic;

namespace ToiLamKyThuat.Data.Models
{
    public partial class PostComment : BaseModel
    {
        public long? UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public long? ParentId { get; set; }
    }
}
