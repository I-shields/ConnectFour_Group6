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
            StartAI = new Button();
            btn_pvp = new Button();
            SuspendLayout();
            // 
            // StartAI
            // 
            StartAI.Location = new Point(285, 231);
            StartAI.Name = "StartAI";
            StartAI.Size = new Size(171, 23);
            StartAI.TabIndex = 0;
            StartAI.Text = "player vs. AI";
            StartAI.UseVisualStyleBackColor = true;
            StartAI.Click += StartAI_Click_1;
            // 
            // btn_pvp
            // 
            btn_pvp.Location = new Point(285, 269);
            btn_pvp.Name = "btn_pvp";
            btn_pvp.Size = new Size(171, 23);
            btn_pvp.TabIndex = 1;
            btn_pvp.Text = "Player vs. Player";
            btn_pvp.UseVisualStyleBackColor = true;
            btn_pvp.Click += btn_pvp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(btn_pvp);
            Controls.Add(StartAI);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button StartAI;
        private Button btn_pvp;
    }
}
