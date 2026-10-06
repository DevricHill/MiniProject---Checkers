namespace MiniProject___Checkers
{
    partial class OptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnSinglePlayer = new Button();
            btnMultiplayer = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Game Settings";
            // 
            // btnSinglePlayer
            // 
            btnSinglePlayer.Location = new Point(12, 27);
            btnSinglePlayer.Name = "btnSinglePlayer";
            btnSinglePlayer.Size = new Size(83, 23);
            btnSinglePlayer.TabIndex = 1;
            btnSinglePlayer.Text = "Single Player";
            btnSinglePlayer.UseVisualStyleBackColor = true;
            btnSinglePlayer.Click += btnSinglePlayer_Click;
            // 
            // btnMultiplayer
            // 
            btnMultiplayer.Location = new Point(12, 56);
            btnMultiplayer.Name = "btnMultiplayer";
            btnMultiplayer.Size = new Size(83, 23);
            btnMultiplayer.TabIndex = 2;
            btnMultiplayer.Text = "Multiplayer";
            btnMultiplayer.UseVisualStyleBackColor = true;
            btnMultiplayer.Click += btnMultiplayer_Click;
            // 
            // OptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMultiplayer);
            Controls.Add(btnSinglePlayer);
            Controls.Add(label1);
            Name = "OptionForm";
            Text = "OptionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSinglePlayer;
        private Button btnMultiplayer;
    }
}