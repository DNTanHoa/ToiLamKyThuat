using System;
using System.Collections.Generic;
using System.Text;

namespace ToiLamKyThuat.Data.DataTranferObjects
{
    public class SitemapDataTranfer
    {
        public long ID { get; set; }

        public DateTime CreateDate { get; set; }

        public string MetaTitle { get; set; }

        public int IsPost { get; set; }
    }
}
