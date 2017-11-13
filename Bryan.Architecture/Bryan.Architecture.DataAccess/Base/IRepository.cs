using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>The list.</summary>
        /// <param name="selector">The selector.</param>
        /// <param name="predicate">The predicate.</param>
        /// <typeparam name="TResult">TResult</typeparam>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<TResult> List<TResult>(Expression<Func<TEntity, TResult>> selector,
                                          Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        TEntity Get(int id);

        /// <summary>The get.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="select">The select.</param>
        /// <typeparam name="TResult">TResult</typeparam>
        /// <returns>The <see cref="TResult"/>.</returns>
        TResult Get<TResult>(Expression<Func<TEntity, bool>> predicate,
                             Expression<Func<TEntity, TResult>> select);

        /// <summary>The get.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
    }
}