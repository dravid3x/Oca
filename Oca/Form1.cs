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
        private Random rand = new Random();
        private gameManager gestoreGioco;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gestoreGioco = new gameManager(this);
            gestoreGioco.generaCampo();
        }
    }
}

/*
            piedino.cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256)));
            int nRand = rand.Next(100, 501);
            Casella.Width = nRand;
            Casella.Height = nRand;
            piedino.impostaGrandezza();
*/