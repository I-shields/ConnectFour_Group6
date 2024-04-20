using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    public partial class Form1 : Form
    //required variables
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartAI_Click_1(object sender, EventArgs e)
        {
            MainGame mg = new MainGame();
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
    }
}
