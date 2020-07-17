using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToiLamKyThuat.Data.DataTranferObjects;

namespace ToiLamKyThuat.Data.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TreeMenuDataTranfer<T>> GenerateTree<T, K>(this IEnumerable<T> collection, Func<T, K> id, Func<T, K> parent, K root = default(K))
        {
            foreach (var item in collection.Where(c => parent(c).Equals(root)))
            {
                yield return new TreeMenuDataTranfer<T>
                {
                    Item = item,
                    Childrens = collection.GenerateTree(id, parent, id(item))
                };
            }
        }
    }
}
