using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToiLamKyThuat.Data.DataTranferObjects
{
    public class PostDataTranferForList
    {
        public string CategoryName { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }
        
        public string Summary { get; set; }
        
        public string CoverImage { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateDay => CreateDate.Day.ToString();

        public string CrateMonth => CreateDate.Month.ToString();

        public string CrateYear => CreateDate.Year.ToString();

        public long CreateUser { get; set; }

        public string MetaTitle { get; set; }

        public long ID { get; set; }

    }
}
