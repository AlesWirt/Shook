using iTechArt.Shook.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iTechArt.Repositories
{
    public static class Repository
    {
        private static Clicker _clicker = new Clicker();

        public static Clicker Clicker => _clicker;
        public static void IncreaseClicker()
        {
            _clicker.ClickerCounter += 1;
        }
    }
}
