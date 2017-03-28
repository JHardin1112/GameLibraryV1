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

namespace GameLibraryV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var db = new GameLibraryV1.Models.GamesContext())
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((bool)row.Cells["owned"].Value == true)
                    {
                        var game = db.Games
                            .Where(g => g.Id == row.Cells["id"].Value.ToString()).FirstOrDefault();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            //if (grid.CurrentCell.ColumnIndex == 0)
            //{
            string gameID = grid.CurrentRow.Cells[0].Value.ToString();
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            pictureBox1.ImageLocation = filePath + "\\Media\\" + gameID + ".jpg";
            //}

        }

        private void MyGames_Click(object sender, EventArgs e)
        {
            using (var db = new GameLibraryV1.Models.GamesContext())
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
            ShowAll();
        }

        private void ShowAll()
        {
            using (var db = new GameLibraryV1.Models.GamesContext())
            {
                var games = db.Games
                    .Where(g => g.Region == "NTSC-U")
                    .OrderBy(g => g.Name)
                    .ToList();

                dataGridView1.DataSource = games;
            }
        }
    }
}
