using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
