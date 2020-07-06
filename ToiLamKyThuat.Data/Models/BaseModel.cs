using System;
using System.Collections.Generic;
using System.Text;

namespace ToiLamKyThuat.Data.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public string Note { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdateUser { get; set; }
        public bool? IsActive { get; set; }
    }
}
