namespace MiniProject___Checkers
{
    partial class HelpForm
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
            label2 = new Label();
            rtxtInstruction = new RichTextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Snap ITC", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(275, 9);
            label2.Name = "label2";
            label2.Size = new Size(199, 31);
            label2.TabIndex = 1;
            label2.Text = "Instructions";
            // 
            // rtxtInstruction
            // 
            rtxtInstruction.Enabled = false;
            rtxtInstruction.Location = new Point(12, 70);
            rtxtInstruction.Name = "rtxtInstruction";
            rtxtInstruction.Size = new Size(776, 368);
            rtxtInstruction.TabIndex = 2;
            rtxtInstruction.Text = "";
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(rtxtInstruction);
            Controls.Add(label2);
            Name = "HelpForm";
            Text = "HelpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private RichTextBox rtxtInstruction;
    }
}