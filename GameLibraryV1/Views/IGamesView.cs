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

        void SaveChanges();
        void ClearGrid();
        void AddGameToGrid(Game game);
        void RemoveGameFromGrid(Game game);
        void UpdateGridWithChangedGame(Game game);
        int GetIdOfSelectedGameInGrid();
        void SetSelectedGameInGrid(Game game);
        void LoadGrid(IList<Game> games);
        void DisplaySelectedGameCover(string fileLocation);

        event EventHandler ShowAll;
        event EventHandler ShowMyGames;
        event EventHandler ShowMyDiscGames;
        event EventHandler ShowMyeShopGames;
        event EventHandler DisplayCover;

        int Id { get; set; }
        string GameId { get; set; }
        string type { get; set; }
        string region { get; set; }
        string name { get; set; }
        bool owned { get; set; }
    }
}
