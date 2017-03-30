using GameLibraryV1.Models;
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
        void ClearGrid();
        void AddGameToGrid(Game game);
        void RemoveGameFromGrid(Game game);
        void UpdateGridWithChangedGame(Game game);
        int GetIdOfSelectedGameInGrid();
        void SetSelectedGameInGrid(Game game);

        int Id { get; set; }
        string GameId { get; set; }
        string type { get; set; }
        string region { get; set; }
        string name { get; set; }
        bool owned { get; set; }
    }
}
