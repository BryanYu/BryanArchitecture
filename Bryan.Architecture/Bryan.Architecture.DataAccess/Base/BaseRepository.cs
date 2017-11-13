using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DataAccess.Base
{
    /// <summary>The base repository.</summary>
    /// <typeparam name="TEntity">TEntity</typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>The _context.</summary>
        private readonly DbContext _context;

        /// <summary>Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.</summary>
        /// <param name="context">The context.</param>
        public BaseRepository(DbContext context)
        {
            this._context = context;
        }

        /// <summary>The insert.</summary>
        /// <param name="entity">The entity.</param>
        public void Insert(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            this._context.SaveChanges();
        }

        /// <summary>The update.</summary>
        /// <param name="entity">The entity.</param>
        public void Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
        }

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            var entity = this.Get(id);
            this._context.Set<TEntity>().Remove(entity);
            this._context.SaveChanges();
        }

        /// <summary>The delete.</summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
            this._context.SaveChanges();
        }

        /// <summary>The save changes.</summary>
        public void SaveChanges()
        {
            this.SaveChanges();
        }

        /// <summary>The list all.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public IQueryable<TEntity> ListAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var result = this._context.Set<TEntity>().AsQueryable();

            if (predicate != null)
            {
                result = result.Where(predicate);
            }
            return result;
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        public TEntity Get(int id)
        {
            var result = this._context.Set<TEntity>().Find(id);
            return result;
        }
    }
}