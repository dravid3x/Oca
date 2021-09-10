using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oca
{
    public class pedina : PictureBox
    {
        private Size dimensioni = new Size(40, 40);
        private Point posizione = new Point(380, 380);
        private Color colorePedina = Color.DeepPink;
        private int posizioneInCasella = 1;
        private int percentualeDimensione = 30;
        private int nCasellaOspitante = 0;

        public pedina()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = posizione;
            Size = dimensioni;
            Paint += new PaintEventHandler(Picturebox_Paint);
            BackColor = Color.Transparent;
            Click += onClick;
        }

        private void Picturebox_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush drawBrush = new SolidBrush(colorePedina);

            e.Graphics.FillEllipse(
            drawBrush,
            0, 0, Size.Width, Size.Height);
        }

        public void cambiaColore(Color nuovoColore)
        {
            colorePedina = nuovoColore;
            Invalidate();
        }

        private void onClick(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorePedina = colorPicker.Color;
                Invalidate();
            }
        }

        public void impostaGrandezza()
        {
            Size = new Size((percentualeDimensione * Parent.Size.Width) / 100, (percentualeDimensione * Parent.Size.Height) / 100);
            PosizioneInCasella = posizioneInCasella;
        }

        public int PosizioneInCasella
        {
            //Funzione per impostare o ricevere la posizione nella casella di rierimento, scegliendo tra tutti e 4 gli angoli della casella
            get { return posizioneInCasella; }
            set
            {
                posizioneInCasella = value;
                switch (value)
                {
                    case 1:     //In alto a sinistra
                        Location = new Point(0, 0);
                        break;
                    case 2:     //In alto centrale
                        Location = new Point((Parent.Size.Width / 2) - (Size.Width / 2), 0);
                        break;
                    case 3:     //In alto a destra
                        Location = new Point(Parent.Size.Width - Size.Width, 0);
                        break;
                    case 4:     //Centrale a sinistra
                        Location = new Point(0, (Parent.Size.Height / 2) - (Size.Height / 2));
                        break;
                    case 5:     //Centrale a destra
                        Location = new Point(Parent.Size.Width - Size.Width, (Parent.Size.Height / 2) - (Size.Height / 2));
                        break;
                    case 6:     //In basso a sinistra
                        Location = new Point(0, Parent.Size.Height - Size.Height);
                        break;
                    case 7:     //In basso centrale
                        Location = new Point((Parent.Size.Width / 2) - (Size.Width / 2), Parent.Size.Height - Size.Height);
                        break;
                    case 8:     //In basso a destra
                        Location = new Point(Parent.Size.Width - Size.Width, Parent.Size.Height - Size.Height);
                        break;
                    default:
                        Location = new Point(Parent.Size.Width - Size.Width, Parent.Size.Height - Size.Height);
                        break;
                }
            }
        }

        public int NCasellaOspitante { get { return nCasellaOspitante; } set { nCasellaOspitante = value; } }

    }
}
