using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToiLamKyThuat.Data.DataTranferObjects;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public class PostRespository : Respository<Post>, IPostRespository
    {
        private readonly ToiLamKyThuatContext _context;

        public PostRespository(ToiLamKyThuatContext context) : base(context)
        {
            _context = context;
        }

        public List<PostDataTranferForList> GetPostDataTranfersByPageAndPageSizeToList(int Page, int PageSize)
        {
            return _context.Set<PostDataTranferForList>().FromSqlRaw("sprocPostGetDataTranfer").AsEnumerable().Skip(Page * PageSize).Take(PageSize).ToList();
        }

        public List<PostDataTranferForList> GetPostDataTranfersToList()
        {
            return _context.Set<PostDataTranferForList>().FromSqlRaw("sprocPostGetDataTranfer").AsEnumerable().ToList();
        }

        public List<SitemapDataTranfer> GetSitemapDataTranferByCodeAndConfig(string Config, string Code)
        {
            SqlParameter[] parameter = 
            {
                new SqlParameter("@Config",Config),
                new SqlParameter("@Code",Code)
            };
            return _context.Set<SitemapDataTranfer>().FromSqlRaw("sprocSitemapGetInforByCodeAndConfig @Config,@Code", parameter).ToList();
        }
    }
}
