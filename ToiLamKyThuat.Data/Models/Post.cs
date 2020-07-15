using System;
using System.Collections.Generic;

namespace ToiLamKyThuat.Data.Models
{
    public partial class Post : BaseModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string CoverImage { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
    }
}
