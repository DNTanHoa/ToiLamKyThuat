using System;
using System.Collections.Generic;

namespace ToiLamKyThuat.Data.Models
{
    public partial class PostContent : BaseModel
    {
        public string PostId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string ImageDescription { get; set; }
        public string ImageMetaKeyword { get; set; }
        public string ImageMetaTitle { get; set; }
        public string ImageMetaDesciption { get; set; }
    }
}
