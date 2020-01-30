using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablaBingo
{
    public partial class Principal : Form
    {
        public int[,] matriz;
        public Principal()
        {
            InitializeComponent();
            matriz = new int[5, 5];
            llenarMatriz();
            llenarTabla();
            coloresIniciales();

        }
        public void llenarMatriz()
        {
            Random aleatorio=new Random();
            bool aux = false;
            for(int j=0;j<5;j++)
            for(int i = 0; i < 5; i++)
            {
                aux = false;
                while (!aux)
                {
                    int auxNumero = 0;
                    if (j==0) auxNumero = Convert.ToInt32(aleatorio.Next(1, 16));
                    else if (j==1) auxNumero = Convert.ToInt32(aleatorio.Next(16, 31));
                    else if (j==2) auxNumero = Convert.ToInt32(aleatorio.Next(31, 46));
                    else if (j == 3) auxNumero = Convert.ToInt32(aleatorio.Next(46, 61));
                    else  auxNumero = Convert.ToInt32(aleatorio.Next(61, 76));

                    if ( auxNumero != matriz[j,0] && auxNumero != matriz[j, 1] && auxNumero != matriz[j, 2] && auxNumero != matriz[j, 3] && auxNumero != matriz[j, 4] )
                    {
                            matriz[j, i] = auxNumero;
                            aux = true;
                    }
                }
            }
        }
        public void llenarTabla()
        {
            B1.Text = Convert.ToString(matriz[0, 0]);
            B2.Text = Convert.ToString(matriz[0, 1]);
            B3.Text = Convert.ToString(matriz[0, 2]);
            B4.Text = Convert.ToString(matriz[0, 3]);
            B5.Text = Convert.ToString(matriz[0, 4]);

            I1.Text = Convert.ToString(matriz[1, 0]);
            I2.Text = Convert.ToString(matriz[1, 1]);
            I3.Text = Convert.ToString(matriz[1, 2]);
            I4.Text = Convert.ToString(matriz[1, 3]);
            I5.Text = Convert.ToString(matriz[1, 4]);

            N1.Text = Convert.ToString(matriz[2, 0]);
            N2.Text = Convert.ToString(matriz[2, 1]);
            //N3.Text = Convert.ToString(matriz[2, 2]);
            N4.Text = Convert.ToString(matriz[2, 3]);
            N5.Text = Convert.ToString(matriz[2, 4]);

            G1.Text = Convert.ToString(matriz[3, 0]);
            G2.Text = Convert.ToString(matriz[3, 1]);
            G3.Text = Convert.ToString(matriz[3, 2]);
            G4.Text = Convert.ToString(matriz[3, 3]);
            G5.Text = Convert.ToString(matriz[3, 4]);

            O1.Text = Convert.ToString(matriz[4, 0]);
            O2.Text = Convert.ToString(matriz[4, 1]);
            O3.Text = Convert.ToString(matriz[4, 2]);
            O4.Text = Convert.ToString(matriz[4, 3]);
            O5.Text = Convert.ToString(matriz[4, 4]);
        }

        public void coloresIniciales()
        {
            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;

            I1.BackColor = Color.White;
            I2.BackColor = Color.White;
            I3.BackColor = Color.White;
            I4.BackColor = Color.White;
            I5.BackColor = Color.White;

            N1.BackColor = Color.White;
            N2.BackColor = Color.White;
            N3.BackColor = Color.White;
            N4.BackColor = Color.White;
            N5.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;

            O1.BackColor = Color.White;
            O2.BackColor = Color.White;
            O3.BackColor = Color.White;
            O4.BackColor = Color.White;
            O5.BackColor = Color.White;
        }

        public void comprobarSiGano()
        {
            if (B1.BackColor == Color.DarkGray && B2.BackColor == Color.DarkGray && B3.BackColor == Color.DarkGray && B4.BackColor == Color.DarkGray && B5.BackColor == Color.DarkGray &&
                I1.BackColor == Color.DarkGray && I2.BackColor == Color.DarkGray && I3.BackColor == Color.DarkGray && I4.BackColor == Color.DarkGray && I5.BackColor == Color.DarkGray &&
                N1.BackColor == Color.DarkGray && N2.BackColor == Color.DarkGray  && N4.BackColor == Color.DarkGray && N5.BackColor == Color.DarkGray &&
                G1.BackColor == Color.DarkGray && G2.BackColor == Color.DarkGray && G3.BackColor == Color.DarkGray && G4.BackColor == Color.DarkGray && G5.BackColor == Color.DarkGray &&
                O1.BackColor == Color.DarkGray && O2.BackColor == Color.DarkGray && O3.BackColor == Color.DarkGray && O4.BackColor == Color.DarkGray && I5.BackColor == Color.DarkGray) MessageBox.Show("Ha ganado, felicitaciones");


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!(B1.BackColor == Color.DarkGray || B2.BackColor == Color.DarkGray || B3.BackColor == Color.DarkGray || B4.BackColor == Color.DarkGray || B5.BackColor == Color.DarkGray ||
                I1.BackColor == Color.DarkGray || I2.BackColor == Color.DarkGray || I3.BackColor == Color.DarkGray || I4.BackColor == Color.DarkGray || I5.BackColor == Color.DarkGray ||
                N1.BackColor == Color.DarkGray || N2.BackColor == Color.DarkGray || N4.BackColor == Color.DarkGray || N5.BackColor == Color.DarkGray ||
                G1.BackColor == Color.DarkGray || G2.BackColor == Color.DarkGray || G3.BackColor == Color.DarkGray || G4.BackColor == Color.DarkGray || G5.BackColor == Color.DarkGray ||
                O1.BackColor == Color.DarkGray || O2.BackColor == Color.DarkGray || O3.BackColor == Color.DarkGray || O4.BackColor == Color.DarkGray || I5.BackColor == Color.DarkGray))
            {
                llenarMatriz();
                llenarTabla();
                coloresIniciales();
            }
            else
            {
                if(MessageBox.Show("El juego ya ha empezado, ¿esta seguro de cambiar de tabla?", "Advertencia", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    llenarMatriz();
                    llenarTabla();
                    coloresIniciales();
                }
            }
            
        }

        private void B1_Click(object sender, EventArgs e)
        {
            if (B1.BackColor == Color.DarkGray) { B1.BackColor = Color.White; return; }
            B1.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void B2_Click(object sender, EventArgs e)
        {
            if (B2.BackColor == Color.DarkGray) { B2.BackColor = Color.White; return; }
            B2.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void B3_Click(object sender, EventArgs e)
        {
            if (B3.BackColor == Color.DarkGray) { B3.BackColor = Color.White; return; }
            B3.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void B4_Click(object sender, EventArgs e)
        {
            if (B4.BackColor == Color.DarkGray) { B4.BackColor = Color.White; return; }
            B4.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void B5_Click(object sender, EventArgs e)
        {
            if (B5.BackColor == Color.DarkGray) { B5.BackColor = Color.White; return; }
            B5.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void I1_Click(object sender, EventArgs e)
        {
            if (I1.BackColor == Color.DarkGray) { I1.BackColor = Color.White; return; }
            I1.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void I2_Click(object sender, EventArgs e)
        {
            if (I2.BackColor == Color.DarkGray) { I2.BackColor = Color.White; return; }
            I2.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void I4_Click(object sender, EventArgs e)
        {
            if (I4.BackColor == Color.DarkGray) { I4.BackColor = Color.White; return; }
            I4.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void I3_Click(object sender, EventArgs e)
        {
            if (I3.BackColor == Color.DarkGray) { I3.BackColor = Color.White; return; }
            I3.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void I5_Click(object sender, EventArgs e)
        {
            if (I5.BackColor == Color.DarkGray) { I5.BackColor = Color.White; return; }
            I5.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void N1_Click(object sender, EventArgs e)
        {
            if (N1.BackColor == Color.DarkGray) { N1.BackColor = Color.White; return; }
            N1.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void N2_Click(object sender, EventArgs e)
        {
            if (N2.BackColor == Color.DarkGray) { N2.BackColor = Color.White; return; }
            N2.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void N4_Click(object sender, EventArgs e)
        {
            if (N4.BackColor == Color.DarkGray) { N4.BackColor = Color.White; return; }
            N4.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void N5_Click(object sender, EventArgs e)
        {
            if (N5.BackColor == Color.DarkGray) { N5.BackColor = Color.White; return; }
            N5.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void G1_Click(object sender, EventArgs e)
        {
            if (G1.BackColor == Color.DarkGray) { G1.BackColor = Color.White; return; }
            G1.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void G2_Click(object sender, EventArgs e)
        {
            if (G2.BackColor == Color.DarkGray) { G2.BackColor = Color.White; return; }
            G2.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void G3_Click(object sender, EventArgs e)
        {
            if (G3.BackColor == Color.DarkGray) { G3.BackColor = Color.White; return; }
            G3.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void G4_Click(object sender, EventArgs e)
        {
            if (G4.BackColor == Color.DarkGray) { G4.BackColor = Color.White; return; }
            G4.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void G5_Click(object sender, EventArgs e)
        {
            if (G5.BackColor == Color.DarkGray) { G5.BackColor = Color.White; return; }
            G5.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void O1_Click(object sender, EventArgs e)
        {
            if (O1.BackColor == Color.DarkGray) { O1.BackColor = Color.White; return; }
            O1.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void O2_Click(object sender, EventArgs e)
        {
            if (O2.BackColor == Color.DarkGray) { O2.BackColor = Color.White; return; }
            O2.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void O3_Click(object sender, EventArgs e)
        {
            if (O3.BackColor == Color.DarkGray) { O3.BackColor = Color.White; return; }
            O3.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void O4_Click(object sender, EventArgs e)
        {
            if (O4.BackColor == Color.DarkGray) { O4.BackColor = Color.White; return; }
            O4.BackColor = Color.DarkGray;
            comprobarSiGano();
        }

        private void O5_Click(object sender, EventArgs e)
        {
            if (O5.BackColor == Color.DarkGray) { O5.BackColor = Color.White; return; }
            O5.BackColor = Color.DarkGray;
            comprobarSiGano();
        }
    }
}
