using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oca
{
    public partial class Form1 : Form
    {
        private casella Casella = new casella(0, 69);
        private pedina piedino = new pedina();
        private pedina piedino2 = new pedina();
        private pedina piedino3 = new pedina();
        private pedina piedino4 = new pedina();
        private pedina piedino5 = new pedina();
        private pedina piedino6 = new pedina();
        private pedina piedino7 = new pedina();
        private pedina piedino8 = new pedina();
        private int posInCasella = 2;
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            dado dice = new dado();
            Controls.Add(dice);

            Casella.Location = new Point(400, 400);
            Controls.Add(Casella);

            Casella.Controls.Add(piedino);
            piedino.PosizioneInCasella = 1;
            piedino.impostaGrandezza();

            Casella.Controls.Add(piedino2);
            piedino2.PosizioneInCasella = 2;
            piedino2.impostaGrandezza();

            Casella.Controls.Add(piedino3);
            piedino3.PosizioneInCasella = 3;
            piedino3.impostaGrandezza();

            Casella.Controls.Add(piedino4);
            piedino4.PosizioneInCasella = 4;
            piedino4.impostaGrandezza();

            Casella.Controls.Add(piedino5);
            piedino5.PosizioneInCasella = 5;
            piedino5.impostaGrandezza();

            Casella.Controls.Add(piedino6);
            piedino6.PosizioneInCasella = 6;
            piedino6.impostaGrandezza();

            Casella.Controls.Add(piedino7);
            piedino7.PosizioneInCasella = 7;
            piedino7.impostaGrandezza();

            Casella.Controls.Add(piedino8);
            piedino8.PosizioneInCasella = 8;
            piedino8.impostaGrandezza();

            Timer test = new Timer();
            test.Interval = 1000;
            test.Tick += Test_Tick;
            test.Enabled = true;
        }

        private void Test_Tick(object sender, EventArgs e)
        {
            piedino.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino2.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino3.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino4.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino5.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino6.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino7.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            piedino8.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            int nRand = rand.Next(100, 501);
            Casella.Width = nRand;
            Casella.Height = nRand;
            piedino.impostaGrandezza();
            piedino2.impostaGrandezza();
            piedino3.impostaGrandezza();
            piedino4.impostaGrandezza();
            piedino5.impostaGrandezza();
            piedino6.impostaGrandezza();
            piedino7.impostaGrandezza();
            piedino8.impostaGrandezza();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
