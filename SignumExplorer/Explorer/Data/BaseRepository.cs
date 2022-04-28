using Microsoft.EntityFrameworkCore;
using SignumExplorer.Context;
using SignumExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignumExplorer.Data
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
    }


    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly IDbContextFactory<ExplorerContext> _contextFactory;

        public BaseRepository(IDbContextFactory<ExplorerContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }




        public async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {

                using (var context = _contextFactory.CreateDbContext())
                {
                    return await context.Set<TEntity>().AsNoTracking().ToListAsync();
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var item = await context.Set<TEntity>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
                    if (item == null)
                    {
                        throw new Exception($"Couldn't find entity with id={id}");
                    }
                    return item;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity with id={id}: {ex.Message}");
            }
        }

        public async Task<TEntity> CreateAsync(TEntity data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    await context.Set<TEntity>().AddAsync(data);
                    await context.SaveChangesAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Set<TEntity>().Update(data);
                    await context.SaveChangesAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} could not be updated: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"{nameof(id)} could not be found.");
                }

                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }

}