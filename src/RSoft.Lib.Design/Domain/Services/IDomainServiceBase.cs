﻿using RSoft.Lib.Design.Domain.Entities;

namespace RSoft.Lib.Design.Domain.Services
{

    /// <summary>
    /// Services domain insterface
    /// </summary>
    public interface IDomainServiceBase<TEntity, TKey> : ICommonBase<TEntity, TKey>
        where TEntity : EntityBase<TEntity>
        where TKey : struct
    {

    }

}
