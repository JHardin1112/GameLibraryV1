using GameLibraryV1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryV1.Controllers
{

    public class GamesController
    {
        //Notice we only use the interfaces. This makes the test more 
        //robust to changes in the system.
        Views.IGamesView _view;
        IList _games;
        Game _selectedGame;

        //The GamesController depends on abstractions(interfaces).
        //It's easier than ever to change the behavior of a concrete class. 
        //Instead of creating concrete objects in GamesController class, 
        //we pass the objects to the constructor of GamesController
        public GamesController(Views.IGamesView view, IList games)
        {
            _view = view;
            _games = games;
            view.SetController(this);
        }

        public IList Games
        {
            get { return ArrayList.ReadOnly(_games); }
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

        public void LoadView()
        {
            _view.ClearGrid();

            foreach (Game game in _games)
            {
                _view.AddGameToGrid(game);
            }

            _view.SetSelectedGameInGrid((Game)_games[0]);
        }

        public void SelectedGameChanged(int selectedGameId)
        {
            foreach (Game game in this._games)
            {
                if (game.Id == selectedGameId)
                {
                    _selectedGame = game;
                    updateViewDetailValues(game);
                    _view.SetSelectedGameInGrid(game);
                    break;
                }
            }
        }

        public void AddNewGame()
        {
            _selectedGame = new Game("", "", "", "", true);
            this.updateViewDetailValues(_selectedGame);
        }

        public void RemoveGame()
        {
            int id = this._view.GetIdOfSelectedGameInGrid();
            Game gameToRemove = null;

            foreach (Game game in this._games)
            {
                if (game.Id == id)
                {
                    gameToRemove = game;
                    break;
                }
            }

            if (gameToRemove != null)
            {
                int newSelectedIndex = this._games.IndexOf(gameToRemove);
                this._games.Remove(gameToRemove);
                this._view.RemoveGameFromGrid(gameToRemove);

                if (newSelectedIndex > -1 && newSelectedIndex < _games.Count)
                {
                    this._view.SetSelectedGameInGrid((Game)_games[newSelectedIndex]);
                }
            }
        }

        public void Save()
        {
            updateGameWithViewValues(_selectedGame);

            if (this._games.Contains(_selectedGame) == false) 
            {
                //add new game
                this._games.Add(_selectedGame);
                this._view.AddGameToGrid(_selectedGame);
            }
            else
            {
                //Update existing game
                this._view.UpdateGridWithChangedGame(_selectedGame);
            }

            _view.SetSelectedGameInGrid(_selectedGame);
        }

    }

}
