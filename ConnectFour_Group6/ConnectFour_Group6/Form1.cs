//Joshua Sell and Isaac Shields
//Program that plays connect four in vs. AI mode or two player mode
//5-5-2024

using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    public partial class Form1 : Form
    //required variables
    {
        private MainGame prevgame;
        private MainGame curgame;
        public Form1()
        {
            InitializeComponent();
        }

        private void StartAI_Click_1(object sender, EventArgs e)
        {
            MainGame mg = new MainGame(1, this);
            curgame = mg;
            this.Hide();
            mg.Show();
        }


        private void GameBoard_MouseHover(object sender, EventArgs e)
        {
        }

        private async void GameBoard_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void GameBoard_MouseEnter(object sender, EventArgs e)
        {

        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void GameBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        private void GameBoard_Click(object sender, EventArgs e)
        {
        }

        private void btn_pvp_Click(object sender, EventArgs e)
        {
            MainGame mg = new MainGame(2, this);
            this.Hide();
            mg.Show();
            curgame = mg;
        }

        public void setPrevGame(MainGame game)
        {
            prevgame = game;
        }

        public MainGame getPrevGame()
        {
            return prevgame;
        }

        private void ShowStats_Btn_Click(object sender, EventArgs e)
        {
            //start the stats
            statsForm sf = new statsForm(5, this);
            sf.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit the program
            Environment.Exit(1);
        }

        public MainGame getCurGame()
        {
            return curgame;
        }

        private void Exit_Btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
