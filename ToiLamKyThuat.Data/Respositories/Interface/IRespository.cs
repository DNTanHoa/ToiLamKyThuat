using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public interface IRespository<T> where T : BaseModel
    {
        public Task<int> AsyncCreate(T model);

        public Task<int> AsyncUpdate(int ID, T model);

        public Task<int> AsyncDelete(int ID);

        public Task<List<T>> AsyncGetAllToList();

        public Task<T> AsyncGetByID(int ID);

        public int Create(T model);

        public int Update(int ID, T model);

        public int Delete(int ID);

        public List<T> GetAllToList();

        public T GetByID(int ID);
    }
}
