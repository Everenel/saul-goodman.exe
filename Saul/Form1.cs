using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Saul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            new Thread(() =>
            {
                while (true) 
                { 
                    Zmienpozycjeokna();

                    Thread.Sleep(50);
                
                }
            }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetSauled1 gs = new GetSauled1();
            gs.Show();
        }

        private Random rnd = new Random();

        void Zmienpozycjeokna()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate {
                    this.Location = new Point(rnd.Next(1, Screen.PrimaryScreen.Bounds.Width - 627), rnd.Next(1, Screen.PrimaryScreen.Bounds.Height - 349));
                });
            }
            catch
            {

            }        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
