using System;

namespace MongoTest.Repository
{
    public interface IEntity<TEntity> where TEntity : class
    {
        Guid Id { get; }
    }
}
