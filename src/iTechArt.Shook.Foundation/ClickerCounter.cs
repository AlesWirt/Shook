using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Foundation
{
    public class ClickerCounter
    {
        private GenericUnitOfWork<ClickerDbContext> _unitOfWork = new GenericUnitOfWork<ClickerDbContext>();
        private Clicker _clicker;

        public Clicker Clicker
        {
            get 
            { 
                return _unitOfWork
                .GenericRepository<Clicker, ClickerDbContext>()
                .GetById((int)1);
            }
        }
        public ClickerCounter()
        {
            _clicker = Clicker;
        }

        public Clicker IncreaseClicker()
        {
            _clicker.ClickerCounter += 1;
            _unitOfWork.GenericRepository<Clicker, ClickerDbContext>().Update(_clicker);
            return _clicker;
        }

    }
}
