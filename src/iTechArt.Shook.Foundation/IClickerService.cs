using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Foundation
{
    public interface IClickerService
    {
        public Clicker GetClicker();
        public Clicker Update();
    }
}
