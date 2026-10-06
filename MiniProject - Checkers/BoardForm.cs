using MiniProject___Checkers.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MiniProject___Checkers
{
    public partial class BoardForm : Form
    {
        Checkers newCheckers = new Checkers();

        
        public BoardForm()
        {
            InitializeComponent();
        }

        Button[,] buttons = new Button[8, 8];

        void SetUp()
        {
            int space = 60;
            for (int x = 0; x < newCheckers.RowSize; x++)
            {
                for (int y = 0; y < newCheckers.ColumnSize; y++)
                {
                    Button button = new Button();
                    button.Size = new Size(60, 60);
                    button.Location = new Point( (y + 1) * space, (x + 1) * space);

                    buttons[x, y] = button;
                    this.Controls.Add(button);
                }
            }
        }

        void CurrentBoard()
        {
            for (int x = 0; x < newCheckers.RowSize; x++)
            {
                for (int y = 0; y < newCheckers.ColumnSize; y++)
                {
                    Button button = buttons[x, y];

                    switch (newCheckers.CheckerBoard[$"{x} {y}"]) { 
                        case 'B':
                            button.BackColor = Color.Gray;
                            button.Tag = null;
                            button.Image = null;
                            break;
                        case 'x':
                            button.BackColor = Color.Gray;
                            button.Image = new Bitmap(Properties.Resources.Black_Piece, new Size(30, 30));
                            button.Tag = 'x';
                            break;
                        case 'y':
                            button.BackColor = Color.Gray;
                            button.Image = new Bitmap(Properties.Resources.Red_Piece, new Size(30, 30));
                            button.Tag = 'y';
                            break;
                        case 'W':
                            button.BackColor = Color.White;
                            button.Tag = null;
                            button.Image = null;
                            break;
                    }
                    button.Invalidate();
                }
               

            }
        }
        

        private Button[] selected = new Button[2];
        private int counter = 0;
        private void AnyButton_Click(object sender, EventArgs e)
        {
            
            Button clicked = (Button)sender;

            int col = clicked.Location.X / 60 - 1;
            int row = clicked.Location.Y / 60 - 1;
            

            if (clicked.BackColor == Color.Gray) 
            {
                if (counter == 0)
                {
                    if (clicked.Image != null && clicked.Tag.ToString() == newCheckers.Turn.ToString())
                    {
                        selected[counter] = clicked;
                        txtGridInfo.Text = $"{row + 1}, {col + 1}";
                        counter++;
                    }
                }
                else if (counter == 1)
                {
                    selected[1] = clicked;

                    int prevCol = selected[0].Location.X / 60 - 1, prevRow = selected[0].Location.Y / 60 - 1;

                    if (newCheckers.PlaceChip(prevRow, prevCol, row, col))
                    {
                        selected[1].Image = selected[0].Image;
                        selected[1].Tag = selected[0].Tag;

                        selected[0].Image = null;
                        selected[0].Tag = null;

                        newCheckers.SwitchTurn();

                        txtGridInfo.Text = $"Moved {prevRow + 1}, {prevCol + 1} to {row + 1}, {col + 1}";
                    }
                    else
                    {
                        txtGridInfo.Text = "That is not a valid choice";
                    }

                    counter = 0;
                    selected = new Button[2];
                }  
            }
            else
            {
                txtGridInfo.Text = $"That is not a playable area!";
            }

            CurrentBoard();
            ShowTurn();

        }

        private void ShowTurn()
        {
            if (newCheckers.Turn == 'x') pBoxTurn.Image = new Bitmap(Properties.Resources.Black_Piece, new Size(60, 60));
            else pBoxTurn.Image = new Bitmap(Properties.Resources.Red_Piece, new Size(60, 60));
        }

        private void BoardForm_Load(object sender, EventArgs e)
        {
            SetUp();
            CurrentBoard();

            if (Data.IsSinglePlayer) SinglePlayer();
            else Multiplayer();

            ShowTurn();

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += AnyButton_Click;
                }
            }
        }

        private void SinglePlayer()
        {
            MessageBox.Show("Single Player Game", "Game Starting");
        }

        private void Multiplayer()
        {
            MessageBox.Show("Multiplayer Player Game", "Game Starting");
        }


    }
}
