using System;
using System.Threading.Tasks;

namespace MongoTest.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
