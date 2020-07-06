using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Respositories
{
    public class Respository<T> : IRespository<T> where T : BaseModel
    {

        private readonly ToiLamKyThuatContext _context;

        public Respository(ToiLamKyThuatContext context)
        {
            _context = context;
        }

        public async Task<int> AsyncCreate(T model)
        {
            _context.Set<T>().Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AsyncDelete(int ID)
        {
            var existModel = await AsyncGetByID(ID);
            if (existModel != null)
            {
                _context.Set<T>().Remove(existModel);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> AsyncGetAllToList()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result ?? new List<T>();
        }

        public async Task<T> AsyncGetByID(int ID)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(model => model.Id == ID);
        }

        public async Task<int> AsyncUpdate(int ID, T model)
        {
            var existModel = await AsyncGetByID(ID);
            if (existModel != null)
            {
                existModel = model;
                _context.Set<T>().Update(existModel);
            }
            return await _context.SaveChangesAsync();
        }

        public int Create(T model)
        {
            _context.Set<T>().Add(model);
            return _context.SaveChanges();
        }

        public int Delete(int ID)
        {
            var existModel = GetByID(ID);
            if (existModel != null)
            {
                _context.Set<T>().Remove(existModel);
            }
            return _context.SaveChanges();
        }

        public List<T> GetAllToList()
        {
            var result = _context.Set<T>().ToList();
            return result ?? new List<T>();
        }

        public T GetByID(int ID)
        {
            return  _context.Set<T>().AsNoTracking().FirstOrDefault(model => model.Id == ID);
        }

        public int Update(int ID, T model)
        {
            var existModel = GetByID(ID);
            if (existModel != null)
            {
                existModel = model;
                _context.Set<T>().Update(existModel);
            }
            return _context.SaveChanges();
        }
    }
}
