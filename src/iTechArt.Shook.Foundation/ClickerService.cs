using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace iTechArt.Shook.Foundation
{
    public class ClickerService : IClickerService
    {
        private readonly IUnitOfWork _uow;
        private Clicker _clicker;

        public Clicker GetClicker()
        {
                return _uow
                .GetRepository<Clicker>()
                .GetById((int)1);
        }
        public ClickerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Clicker Update()
        {
            _clicker.ClickerCounter += 1;
            _uow.GetRepository<Clicker>().Update(_clicker);
            return _clicker;
        }

    }
}
