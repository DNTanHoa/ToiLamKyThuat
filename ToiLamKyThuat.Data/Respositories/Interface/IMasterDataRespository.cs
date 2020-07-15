using System;
using System.Collections.Generic;
using System.Text;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public interface IMasterDataRespository : IRespository<MasterData>
    {
        public List<MasterData> GetByKeyword(string keyword);

        public List<MasterData> GetByConfigAndCode(string Config, string Code);

        public List<MasterData> GetByConfigAndCodeAndKeyword(string Config, string Code, string keyword);
    }
}
