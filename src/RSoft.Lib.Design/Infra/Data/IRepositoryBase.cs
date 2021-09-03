using RSoft.Lib.Design.Domain.Entities;

namespace RSoft.Lib.Design.Infra.Data
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