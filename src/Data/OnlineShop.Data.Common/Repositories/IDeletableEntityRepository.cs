﻿namespace OnlineShop.Data.Common.Repositories
{
    using System.Linq;

    using OnlineShop.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
