using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DataAccess.Base
{
    /// <summary>The Repository interface.</summary>
    /// <typeparam name="TEntity">Data</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>The insert.</summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>The update.</summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        void Delete(int id);

        /// <summary>The delete.</summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>The save changes.</summary>
        void SaveChanges();

        /// <summary>The get all.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<TEntity> ListAll(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        TEntity Get(int id);
    }
}