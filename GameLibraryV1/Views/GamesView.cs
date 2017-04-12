using GameLibraryV1.Presenters;
using GameLibraryV1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibraryV1.Models;

namespace GameLibraryV1
{
    public partial class GamesView : Form, IGamesView
    {
        private GamesPresenter _presenter;

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GameId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string region { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool owned { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //The View published its events.  The Presenter subscribes to these events.
        //When the View fires off an event, it is handled by the Presenter.
        public event EventHandler ShowAll;
        public event EventHandler ShowMyGames;
        public event EventHandler ShowMyDiscGames;
        public event EventHandler ShowMyeShopGames;
        public event EventHandler DisplayCover;
     
        public GamesView()
        {
            InitializeComponent();
            _presenter = new GamesPresenter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAll(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayCover(sender, e);
        }

        private void Selection_Changed(object sender, EventArgs e)
        {
            DisplayCover(sender, e);
        }

        public void LoadGrid(IList<Game> games)
        {
            dataGridView1.DataSource = games;
        }

        public void DisplaySelectedGameCover(string fileLocation)
        {
            pictureBox1.ImageLocation = fileLocation;
        }
                

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var db = new GameLibraryV1.Models.GameContext())
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((bool)row.Cells["owned"].Value == true)
                    {
                        var game = db.Games
                            .Where(g => g.Id == (int)row.Cells["id"].Value).FirstOrDefault();

                        game.Owned = true;

                        db.SaveChanges();
                    }
                }

                //reload grid with recent changes
                var games = db.Games
                   .Where(g => g.Region == "NTSC-U")
                   .OrderBy(g => g.Name)
                   .ToList();

                dataGridView1.DataSource = games;
            }
        }

       private void MyGames_Click(object sender, EventArgs e)
        {
            using (var db = new GameLibraryV1.Models.GameContext())
            {
                var games = db.Games
                    .Where(g => g.Owned == true)
                    .OrderBy(g => g.Name)
                    .ToList();

                dataGridView1.DataSource = games;
            }
        }

        private void AllGames_Click(object sender, EventArgs e)
        {
            ShowAll(sender,e);
        }

        //private void ShowAll()
        //{
        //    using (var db = new GameLibraryV1.Models.GameContext())
        //    {
        //        var games = db.Games
        //            .Where(g => g.Region == "NTSC-U")
        //            .OrderBy(g => g.Name)
        //            .ToList();

        //        dataGridView1.DataSource = games;
        //    }
        //}

        public void Show_AllGames()
        {
            throw new NotImplementedException();
        }

        public void Show_MyGames()
        {
            throw new NotImplementedException();
        }

        public void Show_MyDiscGames()
        {
            throw new NotImplementedException();
        }

        public void Show_MyeShopGames()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void ClearGrid()
        {
            throw new NotImplementedException();
        }

        public void AddGameToGrid(Game game)
        {
            throw new NotImplementedException();
        }

        public void RemoveGameFromGrid(Game game)
        {
            throw new NotImplementedException();
        }

        public void UpdateGridWithChangedGame(Game game)
        {
            throw new NotImplementedException();
        }

        public int GetIdOfSelectedGameInGrid()
        {
            throw new NotImplementedException();
        }

        public void SetSelectedGameInGrid(Game game)
        {
            throw new NotImplementedException();
        }

      
    }
}
