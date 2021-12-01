using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;
using System;

namespace iTechArt.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClickerDbContext _context;

        private GenericRepository<Clicker> _clickerRepository;

        private bool _isDisposed = false;

        public GenericRepository<Clicker> ClickerRepository => _clickerRepository ?? (_clickerRepository = new GenericRepository<Clicker>(_context));

        public UnitOfWork(ClickerDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool isDisposed)
        {
            if (!_isDisposed)
            {
                if (isDisposed)
                {
                    _context.Dispose();
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
