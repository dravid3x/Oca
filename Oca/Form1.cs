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
        private gameManager gestoreGioco;

        public Form1()
        {
            InitializeComponent();
            Size = new Size(1280, 1024);
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gestoreGioco = new gameManager(this);
            gestoreGioco.generaCampo();
            gestoreGioco.generaDado();
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