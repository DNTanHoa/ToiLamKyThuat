﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public class MasterDataRespository : Respository<MasterData>, IMasterDataRespository
    {
        private readonly ToiLamKyThuatContext _context;

        public MasterDataRespository(ToiLamKyThuatContext context) : base(context)
        {
            _context = context;
        }

        public List<MasterData> GetByKeyword(string keyword)
        {
            return _context.MasterData.Where(item => item.CodeName.Contains(keyword)).ToList();
        }

        public List<MasterData> GetByConfigAndCode(string Config, string Code)
        {
            return _context.MasterData.Where(item => item.Config.Equals(Config) &&
                                                     item.Code.Equals(Code)).ToList();
        }

        public List<MasterData> GetByConfigAndCodeAndKeyword(string Config, string Code, string keyword)
        {
            return _context.MasterData.Where(item => item.Config.Equals(Config) &&
                                                     item.Code.Equals(Code) &&
                                                     item.CodeName.Contains(keyword)).ToList();
        }
    }
}