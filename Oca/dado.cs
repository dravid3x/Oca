using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Oca
{
    class dado : PictureBox
    {
        private const string cartellaDadoWhite = "../../imgs/dice/white/";
        private const string cartellaDadoBlack = "../../imgs/dice/black/";
        private const string randomDiceImg = "NA", rotationDicePrefix = "R", estensione = ".png";
        private string cartellaDado = cartellaDadoBlack;
        private Size dimensioni = new Size(64, 64);
        private int dadoMin = 1, dadoMax = 6;
        private int durataAnimazione = 3, nFacceCambiate = 0, tempoCambioFaccia = 100;
        private int numeroEstratto = -1;
        private bool animazione = true;
        private Random rand = new Random();
        private Timer timerCambioFaccia = new Timer();


        public dado()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;    //Strech dell'immagine
            ImageLocation = cartellaDado + randomDiceImg + estensione;   //Imposto la prima immagine visualizzata
            Location = new Point(150, 150);     //Imposto la posizione del dado
            Size = dimensioni;      //Imposto la dimensione della picturebox
            Click += onClick;   //Associo la funzione di click

            //Animazione
            animazione = true;
            timerCambioFaccia.Interval = tempoCambioFaccia;
            timerCambioFaccia.Tick += TimerCambioFaccia_Tick;



            Console.WriteLine(ImageLocation);
        }

        private void onClick(object sender, EventArgs e)
        {
            //Funzione richiamata al click sul dado. Funzione che richiama l'estrazione di un numero
            TiraDado();
        }

        public int TiraDado()
        {
            if (animazione) AnimazioneTiro();
            numeroEstratto = rand.Next(dadoMin, dadoMax + 1);
            Console.WriteLine(numeroEstratto);
            return numeroEstratto;
        }

        private void AnimazioneTiro()
        {
            nFacceCambiate = 0;
            timerCambioFaccia.Enabled = true;

        }

        private void TimerCambioFaccia_Tick(object sender, EventArgs e)
        {
            if (nFacceCambiate < durataAnimazione)
            {
                randomDiceRotatingFace();
                nFacceCambiate++;
            }
            else
            {
                nFacceCambiate = 0;
                ImageLocation = cartellaDado + numeroEstratto + estensione;
                timerCambioFaccia.Enabled = false;
            }
        }

        private void randomDiceRotatingFace()
        {
            ImageLocation = cartellaDado + rotationDicePrefix + rand.Next(dadoMin, dadoMax + 1) + estensione;
        }


    }
}
