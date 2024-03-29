﻿using DogShop.Models.Base;

namespace DogShop.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //Get all data
        //Task<List<TEntity>> GetAllAsync();
        //Task<IEnumerable<TEntity>> GetAllAsync();
        //IQueryable<TEntity> GetAllAsQueryable();

        //Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //Find
        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);
        IQueryable<TEntity> FindAll();

        //Save
        bool Save();
        Task<bool> SaveAsync();

    }
}
