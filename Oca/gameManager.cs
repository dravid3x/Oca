using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Oca
{
    class gameManager
    {
        private dado Dado = new dado();
        private Point posDado = new Point(500, 500);
        private Form1 miaF1;

        public gameManager(Form1 MiaF1)
        {
            miaF1 = MiaF1;
            Dado.Location = posDado;
            posDado = new Point(miaF1.ClientSize.Width / 2, miaF1.ClientSize.Height / 2);
            Dado.Location = posDado;
            miaF1.Controls.Add(Dado);
            casella Casella = new casella(0, 69);
            pedina Piedino = new pedina();
            Casella.Controls.Add(Piedino);
            miaF1.Controls.Add(Casella);
            Piedino.PosizioneInCasella = 5;
            Piedino.impostaGrandezza();
        }

        public void generaCampo()
        {
            Point posIniziale = new Point(200, 200);
            casella[] casellas = new casella[10];
            Random rand = new Random();

            casellas[0] = new casella(0, rand.Next(0, 100));
            casellas[0].Location = posIniziale;

            for (int i = 1; i < 10; i++)
            {
                casellas[i] = new casella(0, rand.Next(0, 100));
                casellas[i].Location = new Point(casellas[i - 1].Location.X + casellas[i].Size.Width, casellas[i - 1].Location.Y);
                //casellas[i].Location = (i != 0) ? new Point(casellas[i - 1].Location.X + casellas[i].Size.Width, casellas[i - 1].Location.Y) : pos;
            }


            for (int i = 0; i < 10; i++)
            {
                miaF1.Controls.Add(casellas[i]);
            }
        }
    }
}
