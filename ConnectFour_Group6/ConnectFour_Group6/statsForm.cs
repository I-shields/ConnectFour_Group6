using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group6
{
    public partial class statsForm : Form
    {
        private SaveInfo si;
        public statsForm(int p)
        {
            si = new SaveInfo();
            InitializeComponent();
            List<int[]> statList = new List<int[]>();
            statList = si.readFile();
            foreach (int[] stat in statList)
            {
                depthBox.Text += stat[0].ToString() + "\n";
                gamesPlayedBox.Text += stat[1].ToString() + "\n";
                AiWinsBox.Text += stat[2].ToString() + "\n";
                plWinsBox.Text += stat[3].ToString() + "\n";
                tiesBox.Text += stat[4].ToString() + "\n";
                aiWinPerBox.Text += ((float)100 / ((float)stat[1] / (float)stat[2])).ToString($"F{2}") + "%" + "\n";

                depthBox.Text += "===========" + "\n";
                gamesPlayedBox.Text += "===========" + "\n";
                AiWinsBox.Text += "===========" + "\n";
                plWinsBox.Text += "===========" + "\n";
                tiesBox.Text += "===========" + "\n";
                aiWinPerBox.Text += "===========" + "\n";
            }

            if(p == 1)
            {
                Win_Lbl.Text = "Player 1 wins!";
                Win_Lbl.Visible = true;
            }
            else if(p == 2)
            {
                Win_Lbl.Text = "AI wins";
                Win_Lbl.Visible = true;
            }
            else if(p == 3)
            {
                Win_Lbl.Text = "Player 2 wins!";
                Win_Lbl.Visible = true;
            }
            else if(p == 4)
            {
                Win_Lbl.Text = "It's a tie";
                Win_Lbl.Visible = true;
            }
        }

        private void AiWinP_Lbl_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void statsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Form1 mf = new Form1();
            mf.Show();
            this.Hide();
        }
    }
}
