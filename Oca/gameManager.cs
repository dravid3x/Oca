using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Oca
{
    class gameManager
    {
        private const int dimCampo = 65;
        private int nGiocatori = 4;
        public dado Dado = new dado();
        private casella[] campo = new casella[dimCampo];
        private pedina[] giocatori;
        private Point posDado;
        private Form1 miaF1;
        private Label labelTurnoGiocatore = new Label();
        private int turnoGiocatore = 0;
        private int numeroEstratto;

        public gameManager(Form1 MiaF1)
        {
            miaF1 = MiaF1;
        }

        public void generaGiocatori()
        {
            Random rand = new Random();
            //Funzione per l'aggiunta e associazione alle caselle dei giocatori
            giocatori = new pedina[nGiocatori];
            for (int i = 0; i < nGiocatori; i++)
            {
                giocatori[i] = new pedina();        //Inizializzo la nuova pedina
                giocatori[i].cambiaColore(Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
                giocatori[i].NCasellaOspitante = 0;
                campo[0].aggiungiOspite(giocatori[i]);
            }
        }

        public void spostaPedina(int nGiocatore, int nDestinazione)
        {
            campo[giocatori[nGiocatore].NCasellaOspitante].rimuoviOspite(giocatori[nGiocatore]);
            campo[nDestinazione].aggiungiOspite(giocatori[nGiocatore]);
            giocatori[nGiocatore].NCasellaOspitante = nDestinazione;
        }

        public void generaCampo()
        {
            Point posIniziale = new Point(10, 150);
            Random rand = new Random();
            campo[0] = new casella(0, "Inizio");
            campo[0].Location = new Point(posIniziale.X, posIniziale.Y);

            posIniziale.X += campo[0].Size.Width;
            miaF1.Controls.Add(campo[0]);
            Point posTemp = posIniziale;
            bool avanti = true;

            for (int i = 1; i < dimCampo; i++)
            {
                campo[i] = new casella(0, i.ToString());
                campo[i].Location = new Point(posTemp.X, posTemp.Y);
                miaF1.Controls.Add(campo[i]);
                if (i % 9 == 0)
                {
                    posTemp.Y += campo[0].Size.Height;
                    avanti = !avanti;
                }
                else posTemp.X += (avanti) ? campo[i].Size.Width : -campo[i].Size.Width;
            }

            campo[dimCampo - 1].NumeroCasella = "Fine";
        }

        public void generaDado()
        {
            int dimX = miaF1.ClientSize.Width, dimY = miaF1.ClientSize.Height;
            posDado = new Point(dimX - Dado.Size.Width - Dado.Size.Width / 2, 150);
            Dado.Location = posDado;
            miaF1.Controls.Add(Dado);
        }

        public bool dadoAbilitato
        {
            set { Dado.abilitato = value; }
        }

        public int NGiocatori { get { return nGiocatori; } set { nGiocatori = value; } }

        public void generaLabelTurni()
        {
            labelTurnoGiocatore.Location = new Point(10, 50);
            miaF1.Controls.Add(labelTurnoGiocatore);
        }
    }
}
