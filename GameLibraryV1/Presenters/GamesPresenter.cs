using GameLibraryV1.Models;
using GameLibraryV1.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLibraryV1.Presenters
{
    public class GamesPresenter
    {
        //Notice we only use the interfaces. This makes the test more 
        //robust to changes in the system.
        Views.IGamesView _view;
        Game _selectedGame;

        //The GamesPresenter depends on abstractions(interfaces).
        //It's easier than ever to change the behavior of a concrete class. 
        //Instead of creating concrete objects in GamesController class, 
        //we pass the objects to the constructor of GamesController
        public GamesPresenter(IGamesView view)
        {
            _view = view;
            this._view.ShowAll += new EventHandler(ShowAll);
            this._view.DisplayCover += new EventHandler(DisplayCover);
        }

        private void ShowAll(object sender, EventArgs e)
        {
            using (var db = new GameLibraryV1.Models.GameContext())
            {
                var games = db.Games
                    .Where(g => g.Region == "NTSC-U")
                    .OrderBy(g => g.Name)
                    .ToList();

                this._view.LoadGrid(games);
            }
        }

        private void DisplayCover(object sender, EventArgs e)
        {
            string imageLocation;
            DataGridView grid = (DataGridView)sender;

            string gameID = grid.CurrentRow.Cells[1].Value.ToString();
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            imageLocation = filePath + "\\Media\\" + gameID + ".jpg";

            this._view.DisplaySelectedGameCover(imageLocation);
        }

        private void updateViewDetailValues(Game game)
        {
            _view.Id = game.Id;
            _view.GameId = game.GameId;
            _view.region = game.Region;
            _view.type = game.Type;
            _view.name = game.Name;
            _view.owned = game.Owned;

        }

        private void updateGameWithViewValues(Game game)
        {
            game.Id = _view.Id;
            game.GameId = _view.GameId;
            game.Region = _view.region;
            game.Type = _view.type;
            game.Name = _view.name;
            game.Owned = _view.owned;
        }

     

    }
}
