using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Foundation
{
    public interface IClickerService
    {
        public Clicker Insert();

        public Clicker GetClicker();

        public Clicker Update(int id = 1);
    }
}
