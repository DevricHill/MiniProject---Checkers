using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MiniProject___Checkers
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            Data.IsSinglePlayer = true;

            BoardForm boardForm = new BoardForm();
            boardForm.Show();

            this.Hide();
        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            Data.IsSinglePlayer = false;

            BoardForm boardForm = new BoardForm();
            boardForm.Show();

            this.Hide();
        }
    }
}
