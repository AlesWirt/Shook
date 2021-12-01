using System;

namespace iTechArt.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public void SaveChanges();
    }
}
