using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericRepositoryClass
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(AppDbContext context)
        {
            _context = context;

            table = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task Insert(T obj)
        {
            await table.AddAsync(obj);
            await Save();
        }
        public async Task Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await Save();
        }
        public async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
            await Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
