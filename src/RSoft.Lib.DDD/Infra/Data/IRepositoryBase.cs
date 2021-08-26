using RSoft.Lib.DDD.Domain.Entities;

namespace RSoft.Lib.DDD.Infra.Data
{

    /// <summary>
    /// Generic repository interface
    /// </summary>
    public interface IRepositoryBase<TEntity, TKey> : ICommonBase<TEntity, TKey>
        where TEntity : EntityBase<TEntity>
        where TKey : struct
    {

    }

}