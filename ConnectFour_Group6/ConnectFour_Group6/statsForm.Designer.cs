namespace ConnectFour_Group6
{
    partial class statsForm
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
            Depth_Lbl = new Label();
            GamesPlayed_Lbl = new Label();
            AiWins_Lbl = new Label();
            PlayerWins_Lbl = new Label();
            Tie_Lbl = new Label();
            AiWinP_Lbl = new Label();
            depthBox = new RichTextBox();
            gamesPlayedBox = new RichTextBox();
            AiWinsBox = new RichTextBox();
            plWinsBox = new RichTextBox();
            tiesBox = new RichTextBox();
            aiWinPerBox = new RichTextBox();
            Return_btn = new Button();
            Win_Lbl = new Label();
            SuspendLayout();
            // 
            // Depth_Lbl
            // 
            Depth_Lbl.AutoSize = true;
            Depth_Lbl.Location = new Point(12, 9);
            Depth_Lbl.Name = "Depth_Lbl";
            Depth_Lbl.Size = new Size(52, 15);
            Depth_Lbl.TabIndex = 0;
            Depth_Lbl.Text = "AI depth";
            // 
            // GamesPlayed_Lbl
            // 
            GamesPlayed_Lbl.AutoSize = true;
            GamesPlayed_Lbl.Location = new Point(118, 9);
            GamesPlayed_Lbl.Name = "GamesPlayed_Lbl";
            GamesPlayed_Lbl.Size = new Size(78, 15);
            GamesPlayed_Lbl.TabIndex = 1;
            GamesPlayed_Lbl.Text = "GamesPlayed";
            // 
            // AiWins_Lbl
            // 
            AiWins_Lbl.AutoSize = true;
            AiWins_Lbl.Location = new Point(224, 9);
            AiWins_Lbl.Name = "AiWins_Lbl";
            AiWins_Lbl.Size = new Size(45, 15);
            AiWins_Lbl.TabIndex = 2;
            AiWins_Lbl.Text = "AI wins";
            // 
            // PlayerWins_Lbl
            // 
            PlayerWins_Lbl.AutoSize = true;
            PlayerWins_Lbl.Location = new Point(330, 9);
            PlayerWins_Lbl.Name = "PlayerWins_Lbl";
            PlayerWins_Lbl.Size = new Size(66, 15);
            PlayerWins_Lbl.TabIndex = 3;
            PlayerWins_Lbl.Text = "Player wins";
            // 
            // Tie_Lbl
            // 
            Tie_Lbl.AutoSize = true;
            Tie_Lbl.Location = new Point(436, 9);
            Tie_Lbl.Name = "Tie_Lbl";
            Tie_Lbl.Size = new Size(27, 15);
            Tie_Lbl.TabIndex = 4;
            Tie_Lbl.Text = "Ties";
            // 
            // AiWinP_Lbl
            // 
            AiWinP_Lbl.AutoSize = true;
            AiWinP_Lbl.Location = new Point(542, 9);
            AiWinP_Lbl.Name = "AiWinP_Lbl";
            AiWinP_Lbl.Size = new Size(102, 15);
            AiWinP_Lbl.TabIndex = 5;
            AiWinP_Lbl.Text = "AI win percentage";
            // 
            // depthBox
            // 
            depthBox.BorderStyle = BorderStyle.None;
            depthBox.Location = new Point(12, 27);
            depthBox.Name = "depthBox";
            depthBox.ReadOnly = true;
            depthBox.Size = new Size(100, 411);
            depthBox.TabIndex = 6;
            depthBox.Text = "";
            // 
            // gamesPlayedBox
            // 
            gamesPlayedBox.BorderStyle = BorderStyle.None;
            gamesPlayedBox.Location = new Point(118, 27);
            gamesPlayedBox.Name = "gamesPlayedBox";
            gamesPlayedBox.ReadOnly = true;
            gamesPlayedBox.Size = new Size(100, 411);
            gamesPlayedBox.TabIndex = 7;
            gamesPlayedBox.Text = "";
            // 
            // AiWinsBox
            // 
            AiWinsBox.BorderStyle = BorderStyle.None;
            AiWinsBox.Location = new Point(224, 27);
            AiWinsBox.Name = "AiWinsBox";
            AiWinsBox.ReadOnly = true;
            AiWinsBox.Size = new Size(100, 411);
            AiWinsBox.TabIndex = 8;
            AiWinsBox.Text = "";
            // 
            // plWinsBox
            // 
            plWinsBox.BorderStyle = BorderStyle.None;
            plWinsBox.Location = new Point(330, 27);
            plWinsBox.Name = "plWinsBox";
            plWinsBox.ReadOnly = true;
            plWinsBox.Size = new Size(100, 411);
            plWinsBox.TabIndex = 9;
            plWinsBox.Text = "";
            // 
            // tiesBox
            // 
            tiesBox.BorderStyle = BorderStyle.None;
            tiesBox.Location = new Point(436, 27);
            tiesBox.Name = "tiesBox";
            tiesBox.ReadOnly = true;
            tiesBox.Size = new Size(100, 411);
            tiesBox.TabIndex = 10;
            tiesBox.Text = "";
            // 
            // aiWinPerBox
            // 
            aiWinPerBox.BorderStyle = BorderStyle.None;
            aiWinPerBox.Location = new Point(542, 27);
            aiWinPerBox.Name = "aiWinPerBox";
            aiWinPerBox.ReadOnly = true;
            aiWinPerBox.Size = new Size(100, 411);
            aiWinPerBox.TabIndex = 11;
            aiWinPerBox.Text = "";
            aiWinPerBox.TextChanged += richTextBox6_TextChanged;
            // 
            // Return_btn
            // 
            Return_btn.Location = new Point(648, 415);
            Return_btn.Name = "Return_btn";
            Return_btn.Size = new Size(126, 23);
            Return_btn.TabIndex = 12;
            Return_btn.Text = "Main Menu";
            Return_btn.UseVisualStyleBackColor = true;
            Return_btn.Click += Return_btn_Click;
            // 
            // Win_Lbl
            // 
            Win_Lbl.AutoSize = true;
            Win_Lbl.Location = new Point(648, 397);
            Win_Lbl.Name = "Win_Lbl";
            Win_Lbl.Size = new Size(126, 15);
            Win_Lbl.TabIndex = 13;
            Win_Lbl.Text = "Who won place holder";
            Win_Lbl.Visible = false;
            Win_Lbl.Click += Win_Lbl_Click;
            // 
            // statsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Win_Lbl);
            Controls.Add(Return_btn);
            Controls.Add(aiWinPerBox);
            Controls.Add(tiesBox);
            Controls.Add(plWinsBox);
            Controls.Add(AiWinsBox);
            Controls.Add(gamesPlayedBox);
            Controls.Add(depthBox);
            Controls.Add(AiWinP_Lbl);
            Controls.Add(Tie_Lbl);
            Controls.Add(PlayerWins_Lbl);
            Controls.Add(AiWins_Lbl);
            Controls.Add(GamesPlayed_Lbl);
            Controls.Add(Depth_Lbl);
            Name = "statsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "statsForm";
            FormClosed += statsForm_FormClosed;
            Load += statsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Depth_Lbl;
        private Label GamesPlayed_Lbl;
        private Label AiWins_Lbl;
        private Label PlayerWins_Lbl;
        private Label Tie_Lbl;
        private Label AiWinP_Lbl;
        private RichTextBox depthBox;
        private RichTextBox gamesPlayedBox;
        private RichTextBox AiWinsBox;
        private RichTextBox plWinsBox;
        private RichTextBox tiesBox;
        private RichTextBox aiWinPerBox;
        private Button Return_btn;
        private Label Win_Lbl;
    }
}