using System;
using System.Collections.Generic;

namespace ToiLamKyThuat.Data.Models
{
    public partial class MasterData : BaseModel
    {
        public string Config { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public long ParentID { get; set; }
    }
}
