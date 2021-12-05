using Microsoft.EntityFrameworkCore;
using System;

namespace iTechArt.Repositories.Interfaces
{
    public interface IGenericUnitOfWork<out TContext> : IDisposable
        where TContext : DbContext, new()
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
