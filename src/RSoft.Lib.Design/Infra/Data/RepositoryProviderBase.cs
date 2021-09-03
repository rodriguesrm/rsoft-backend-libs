using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RSoft.Lib.Design.Domain.Entities;
using RSoft.Lib.Design.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Lib.Design.Infra.Data
{

    /// <summary>
    /// Abstract repository base
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TKey">Entity key type</typeparam>
    public abstract class RepositoryProviderBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : EntityBase<TEntity>
        where TKey : struct
    {

        #region Local objects/variables

        /// <summary>
        /// Database context object
        /// </summary>
        protected DbContext _ctx;

        /// <summary>
        /// Dbset object
        /// </summary>
        protected DbSet<TEntity> _dbSet;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new repository instance
        /// </summary>
        /// <param name="ctx">Data base context object</param>
        public RepositoryProviderBase(DbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }

        #endregion

        #region Abstract methods

        /// <summary>
        /// Checks if the entity has the same key that was informed (double check)
        /// </summary>
        /// <param name="key">Verification key value</param>
        /// <param name="entity">Instance of key</param>
        protected abstract bool IsKeyOk(TKey key, TEntity entity);

        #endregion

        #region Public Methods

        ///<inheritdoc/>
        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!entity.Valid)
                throw new InvalidEntityException(nameof(entity));
            EntityEntry<TEntity> tsk = await _dbSet.AddAsync(entity, cancellationToken).AsTask();
            return entity;
        }

        ///<inheritdoc/>
        public virtual TEntity Update(TKey key, TEntity entity)
        {
            if (!IsKeyOk(key, entity) || !entity.Valid)
                throw new InvalidEntityException(nameof(entity));
            return _dbSet.Update(entity).Entity;
        }

        ///<inheritdoc/>
        public virtual async Task<TEntity> GetByKeyAsync(TKey key, CancellationToken cancellationToken = default)
        {

            if (cancellationToken.IsCancellationRequested)
                return null;

            TEntity entity = await Task.Run(() => _dbSet.Find(key));

            if (cancellationToken.IsCancellationRequested)
                return null;

            return entity;

        }

        ///<inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {

            if (cancellationToken.IsCancellationRequested)
                return null;

            IEnumerable<TEntity> entities = await _dbSet.ToListAsync(cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return null;

            return entities;

        }

        ///<inheritdoc/>
        public virtual void Delete(TKey key)
        {
            TEntity entity = _dbSet.Find(key);
            if (entity is ISoftDeletion deletion)
            {
                deletion.IsDeleted = true;
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false;

        /// <summary>
        /// Release resources
        /// </summary>
        /// <param name="disposing">Flag to indicate to release internal resource</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }

                _dbSet = null;
                _ctx = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// Destroy object instance and release resources
        /// </summary>
        ~RepositoryProviderBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }

}
