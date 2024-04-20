namespace ConnectFour_Group6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GameBoard = new TableLayoutPanel();
            SuspendLayout();
            // 
            // GameBoard
            // 
            GameBoard.BackColor = Color.White;
            GameBoard.BackgroundImageLayout = ImageLayout.Stretch;
            GameBoard.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            GameBoard.ColumnCount = 7;
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            GameBoard.Location = new Point(12, 12);
            GameBoard.Name = "GameBoard";
            GameBoard.RowCount = 6;
            GameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            GameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            GameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            GameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            GameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            GameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            GameBoard.Size = new Size(776, 425);
            GameBoard.TabIndex = 0;
            GameBoard.MouseEnter += GameBoard_MouseEnter;
            GameBoard.MouseHover += GameBoard_MouseHover;
            GameBoard.MouseMove += GameBoard_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(GameBoard);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel GameBoard;
    }
}
