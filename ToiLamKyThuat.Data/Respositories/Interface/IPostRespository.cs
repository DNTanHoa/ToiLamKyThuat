using System;
using System.Collections.Generic;
using System.Text;
using ToiLamKyThuat.Data.DataTranferObjects;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public interface IPostRespository : IRespository<Post>
    {
        public List<PostDataTranferForList> GetPostDataTranfersToList();

        public List<PostDataTranferForList> GetPostDataTranfersByPageAndPageSizeToList(int Page, int PageSize);
    }
}
