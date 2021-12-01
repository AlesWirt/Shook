using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Foundation
{
    public class ClickerCounter
    {
        public UnitOfWork Uow { get; }


        public ClickerCounter(ClickerDbContext context)
        {
            Uow = new UnitOfWork(context);
        }

        public Clicker IncreaseClicker()
        {
            Clicker clicker = Uow.ClickerRepository.Read(1);
            clicker.ClickerCounter += 1;
            Uow.ClickerRepository.Update(clicker);
            Uow.SaveChanges();
            return clicker;
        }
    }
}
