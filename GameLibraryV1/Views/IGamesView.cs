using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryV1.Views
{
    public interface IGamesView
    {
        void SetController(Controllers.GamesController controller);
        void Show_AllGames();
        void Show_MyGames();
        void Show_MyDiscGames();
        void Show_MyeShopGames();
        void SaveChanges();
    }
}
