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
        private pedina Temp = new pedina();
        private int nGiocatoreAttuale = 2;
        private int numeroEstratto;

        public gameManager(Form1 MiaF1)
        {
            miaF1 = MiaF1;
            miaF1.Controls.Add(Temp);
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
                campo[i] = new casella(rand.Next(-5, 6), i.ToString());
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
            Dado.Click += dadoOnClick;
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
            labelTurnoGiocatore.Text = "Turno giocatore";
            labelTurnoGiocatore.Size = new Size(300, 300);
            labelTurnoGiocatore.Font = new Font("Arial", 24, FontStyle.Bold);
            miaF1.Controls.Add(labelTurnoGiocatore);
            aggiornaLabelTurni();
        }

        private void aggiornaLabelTurni()
        {
            Temp.cambiaColore(giocatori[nGiocatoreAttuale].ColorePedina);
            Temp.Size = new Size(64, 64);
            Temp.Location = new Point(310, labelTurnoGiocatore.Location.Y);
        }

        private void dadoOnClick(object sender, EventArgs e)
        {
            //Funzione richiamata al click sul dado. Funzione che richiama l'estrazione di un numero
            numeroEstratto = Dado.tiraDado();
            Timer timerMovimento = new Timer();
            timerMovimento.Interval = 500;
            timerMovimento.Tick += TimerMovimento_Tick;
            timerMovimento.Enabled = true;
            //MessageBox.Show("É uscito il numero " + numeroEstratto.ToString());
        }

        private void TimerMovimento_Tick(object sender, EventArgs e)
        {
            //Funzione per lo spostamento della pedina in base all'estrazione del dado e alla attivazione della casella speciale
            Timer mandante = sender as Timer;
            mandante.Enabled = false;

            //Gestione movimento dato lancio del dado
            int nCasellaArrivo = giocatori[nGiocatoreAttuale].NCasellaOspitante + numeroEstratto;
            spostaPedina(nGiocatoreAttuale, nCasellaArrivo);
            giocatori[nGiocatoreAttuale].NCasellaOspitante = nCasellaArrivo;
            MessageBox.Show("É uscito un " + numeroEstratto.ToString() + "\nIl Giocatore arriva alla casella numero " + nCasellaArrivo.ToString());

            //Movimento dato evento della casella
            bool evento = false;
            string messaggio = "", titolo = "";
            int distanzaMovimento = campo[nCasellaArrivo].DistanzaMovimento;
            int distanzaMovimentoStampa = distanzaMovimento;
            if (distanzaMovimentoStampa < 0) distanzaMovimentoStampa *= -1;
            switch (campo[nCasellaArrivo].TipoCasella)
            {
                case -1:
                    titolo = "Imprevisto";
                    messaggio = "Il giocatore retrocede di " + distanzaMovimentoStampa + " caselle\n";
                    evento = true;
                    break;
                case 0:
                    titolo = "Normale";
                    messaggio = "Il giocatore rimane dov'è";
                    evento = false;
                    break;
                case 1:
                    titolo = "Avanzamento";
                    messaggio = "Il giocatore avanza di " + distanzaMovimentoStampa + " caselle\n";
                    evento = true;
                    break;
                default:
                    break;
            }
            //Eseguo lo spostamento dell'evento
            MessageBox.Show(messaggio, titolo);
            int nuovaCasellaArrivo = nCasellaArrivo + distanzaMovimento;
            spostaPedina(nGiocatoreAttuale, nuovaCasellaArrivo);
            //Imposto il giocatore del turno successivo
            if (nGiocatoreAttuale < nGiocatori - 1) nGiocatoreAttuale++;
            else nGiocatoreAttuale = 0;
            aggiornaLabelTurni();
        }
    }
}
