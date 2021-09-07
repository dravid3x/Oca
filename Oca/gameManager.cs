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
        private const int dim = 65;
        private dado Dado = new dado();
        private casella[] casellas = new casella[dim];
        private Point posDado;
        private Form1 miaF1;

        public gameManager(Form1 MiaF1)
        {
            miaF1 = MiaF1;
        }

        public void generaCampo()
        {
            Point posIniziale = new Point(10, 50);
            Random rand = new Random();
            casellas[0] = new casella(0, "Inizio");
            casellas[0].Location = new Point(posIniziale.X, posIniziale.Y);

            posIniziale.X += casellas[0].Size.Width;
            miaF1.Controls.Add(casellas[0]);
            Point posTemp = posIniziale;
            bool avanti = true;

            for (int i = 1; i < dim; i++)
            {
                casellas[i] = new casella(0, i.ToString());
                casellas[i].Location = new Point(posTemp.X, posTemp.Y);
                miaF1.Controls.Add(casellas[i]);
                if (i % 9 == 0)
                {
                    posTemp.Y += casellas[0].Size.Height;
                    avanti = !avanti;
                } else posTemp.X += (avanti) ? casellas[i].Size.Width : -casellas[i].Size.Width;
            }

            casellas[dim - 1].NumeroCasella = "Fine";
        }

        public void generaDado()
        {
            int dimX = miaF1.ClientSize.Width, dimY = miaF1.ClientSize.Height;
            posDado = new Point(dimX - Dado.Size.Width - Dado.Size.Width / 2, dimY / 2 - Dado.Size.Height * 2);
            Dado.Location = posDado;
            miaF1.Controls.Add(Dado);
        }

        private void nascondiDado()
        {

        }
    }
}
