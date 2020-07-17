using System;
using System.Collections.Generic;
using System.Text;

namespace ToiLamKyThuat.Data.DataTranferObjects
{
    public class TreeMenuDataTranfer<T>
    {
        public T Item { get; set; }

        public IEnumerable<TreeMenuDataTranfer<T>> Childrens { get; set; }
    }
}
