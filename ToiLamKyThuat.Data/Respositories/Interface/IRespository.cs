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

        public Task<int> AsyncUpdate(long ID, T model);

        public Task<int> AsyncDelete(long ID);

        public Task<List<T>> AsyncGetAllToList();

        public Task<T> AsyncGetByID(long ID);

        public int Create(T model);

        public int Update(long ID, T model);

        public int Delete(long ID);

        public List<T> GetAllToList();

        public T GetByID(long ID);

        public List<T> GetByPageAndPageSizeToList(int Page, int PageSzie);
    }
}
