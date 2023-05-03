using DogShop.Data;
using DogShop.Models;
using DogShop.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DogShop.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity //clasa generica si putem trimite ca parametri doar entitati ce au la baza BaseEntity
    {
        protected readonly Context _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(Context context) //dependency injection
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        //public async Task<List<TEntity>> GetAllAsync()
        //{
        //    Console.WriteLine("asdf");
        //    return await _table.AsNoTracking().ToListAsync();
        //}

        //public async Task<IEnumerable<TEntity>> GetAllAsync()
        //{
        //    Console.WriteLine("asdf");
        //    return await _table.ToListAsync();
        //}

        //public IQueryable<TEntity> GetAllAsQueryable()
        //{
        //    return _table.AsQueryable();
        //}

        //Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        //Update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        //Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        //Find
        public TEntity FindById(object id)
        {
            return _table.Find(id);//prima data verifica daca avem ceva date salvate apoi face query
            //return _table.FirstOrDefault(x => x.Id.Equals(id)); //executa mereu queryul pe db 
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);//prima data verifica daca avem ceva date salvate apoi face query
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;//> 0 pt ca The number of state entries written to the database
            }
            catch (SqlException exp)
            {
                Console.WriteLine(exp.ErrorCode);
            }
            return false;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException exp)
            {
                Console.WriteLine(exp.ErrorCode);
            }
            return false;
        }

        //Find guid
        public TEntity FindById(Guid id)
        {
            return _table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return _table;
        }
    }
}