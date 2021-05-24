using AlgoritmoAEstrella.ClasesAuxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoAEstrella
{
    public partial class Form1 : Form
    {
        static int tamañoCuadricula = 5;
        Casilla[,] matriz = new Casilla[tamañoCuadricula, tamañoCuadricula];
        int inicioI, inicioJ, finalI, finalJ;

        List<Casilla> openSet = new List<Casilla>();
        List<Casilla> closedSet = new List<Casilla>();

        Casilla camino = new Casilla();

        Button[,] panel = new Button[tamañoCuadricula, tamañoCuadricula];
        bool inicioColocado = false, finalColocado = false;
        int inicioAnteriorI = 0, inicioAnteriorJ = 0, finalAnteriorI = 0, finalAnteriorJ = 0;

        public Form1()
        {
            InitializeComponent();
            inicioX.SelectedIndex = 0;
            inicioY.SelectedIndex = 0;
            finalX.SelectedIndex = 0;
            finalY.SelectedIndex = 0;
            this.CenterToScreen();
            inicializar();
        }

        public void inicializar()
        {
            for(int i = 0; i < tamañoCuadricula; i++)
            {
                for(int j = 0; j < tamañoCuadricula; j++)
                {
                    matriz[i, j] = new Casilla(0,0,i,j);
                }
            }

            //Asignando botones
            panel[0, 0] = b00;
            panel[0, 1] = b01;
            panel[0, 2] = b02;
            panel[0, 3] = b03;
            panel[0, 4] = b04;
            panel[1, 0] = b10;
            panel[1, 1] = b11;
            panel[1, 2] = b12;
            panel[1, 3] = b13;
            panel[1, 4] = b14;
            panel[2, 0] = b20;
            panel[2, 1] = b21;
            panel[2, 2] = b22;
            panel[2, 3] = b23;
            panel[2, 4] = b24;
            panel[3, 0] = b30;
            panel[3, 1] = b31;
            panel[3, 2] = b32;
            panel[3, 3] = b33;
            panel[3, 4] = b34;
            panel[4, 0] = b40;
            panel[4, 1] = b41;
            panel[4, 2] = b42;
            panel[4, 3] = b43;
            panel[4, 4] = b44;
        }

        public void limpiarCamino()
        {
            for(int i = 0; i < tamañoCuadricula; i++)
            {
                for(int j = 0; j < tamañoCuadricula; j++)
                {
                    if(matriz[i, j].getPasos() > 0 && matriz[i, j].getValor() != 4)
                    {
                        matriz[i, j].setValor(0);
                        matriz[i, j].setPasos(0);
                        panel[i, j].BackColor = Color.FromArgb(220, 220, 220);
                    }
                    else if(matriz[i, j].getValor() == 4)
                    {
                        matriz[i, j].setPasos(0);
                    }
                }
            }

            closedSet.Clear();
            labelPasos.Text = "0";
            camino = new Casilla();
        }

        public void generarCaminos()
        {
            limpiarCamino();

            if ((inicioI != finalI || inicioJ == finalJ) && (matriz[inicioI, inicioJ].getValor() == 3 && matriz[finalI, finalJ].getValor() == 4))
            {
                openSet.Add(matriz[inicioI, inicioJ]);

                timer1.Start();
            }
            else
            {
                MessageBox.Show("Por favor, revise las coordenas del inicio y el fin");
            }
        }

        private void marcarInicio_Click(object sender, EventArgs e)
        {
            inicioI = Int32.Parse(inicioY.SelectedItem.ToString());
            inicioJ = Int32.Parse(inicioX.SelectedItem.ToString());

            panel[inicioI, inicioJ].BackColor = Color.FromArgb(218, 165, 32);
            panel[inicioI, inicioJ].Text = "I";
            matriz[inicioI, inicioJ].setValor(3);

            if (inicioColocado == false)
            {
                inicioColocado = true;
            }
            else
            {
                panel[inicioAnteriorI, inicioAnteriorJ].BackColor = Color.FromArgb(220, 220, 220);
                panel[inicioAnteriorI, inicioAnteriorJ].Text = "";
                matriz[inicioAnteriorI, inicioAnteriorJ].setValor(0);
            }

            inicioAnteriorI = inicioI;
            inicioAnteriorJ = inicioJ;

            limpiarCamino();
        }

        private void marcarFinal_Click(object sender, EventArgs e)
        {
            finalI = Int32.Parse(finalY.SelectedItem.ToString());
            finalJ = Int32.Parse(finalX.SelectedItem.ToString());

            panel[finalI, finalJ].BackColor = Color.FromArgb(218, 165, 32);
            panel[finalI, finalJ].Text = "F";
            matriz[finalI, finalJ].setValor(4);

            if(finalColocado == false)
            {
                finalColocado = true;
            }
            else
            {
                panel[finalAnteriorI, finalAnteriorJ].BackColor = Color.FromArgb(220, 220, 220);
                panel[finalAnteriorI, finalAnteriorJ].Text = "";
                matriz[finalAnteriorI, finalAnteriorJ].setValor(0);
            } 

            finalAnteriorI = finalI;
            finalAnteriorJ = finalJ;

            limpiarCamino();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < tamañoCuadricula; i++)
            {
                for(int j = 0; j < tamañoCuadricula; j++)
                {
                    panel[i, j].BackColor = Color.FromArgb(220, 220, 220);
                    panel[i, j].Text = "";
                    matriz[i, j] = new Casilla(0,0,i,j);
                }
            }

            openSet.Clear();
            closedSet.Clear();
            camino = new Casilla();
            inicioI = 0;
            inicioJ = 0;
            finalI = 0;
            finalJ = 0;
            inicioAnteriorI = 0;
            inicioAnteriorJ = 0;
            finalAnteriorI = 0;
            finalAnteriorJ = 0;
            inicioColocado = false;
            finalColocado = false;
            labelPasos.Text = "0";
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            generarCaminos();
            //imprimirMatriz();
        }

        private void bloqueoCasilla(int i, int j)
        {
            if (matriz[i, j].getValor() == 0 || matriz[i, j].getValor() == 2)
            {
                if (matriz[i, j].getValor() == 2)
                {
                    matriz[i, j].setPasos(0);
                }

                matriz[i, j].setValor(1);
                panel[i, j].BackColor = Color.FromArgb(105, 105, 105);
            }
            else if (matriz[i, j].getValor() == 1)
            {
                matriz[i, j].setValor(0);
                panel[i, j].BackColor = Color.FromArgb(220, 220, 220);
            }

            limpiarCamino();
        }

        #region Matriz de botones
        #region Primera Fila
        private void b00_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(0,0);
        }

        private void b01_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(0, 1);
        }

        private void b02_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(0, 2);
        }

        private void b03_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(0, 3);
        }

        private void b04_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(0, 4);
        }
        #endregion

        #region Segunda Fila
        private void b10_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(1, 0);
        }

        private void b11_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(1, 1);
        }

        private void b12_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(1, 2);
        }

        private void b13_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(1, 3);
        }

        private void b14_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(1, 4);
        }
        #endregion

        #region Tercera Fila
        private void b20_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(2, 0);
        }

        private void b21_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(2, 1);
        }

        private void b22_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(2, 2);
        }

        private void b23_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(2, 3);
        }

        private void b24_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(2, 4);
        }
        #endregion

        #region Cuarta Fila
        private void b30_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(3, 0);
        }

        private void b31_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(3, 1);
        }

        private void b32_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(3, 2);
        }

        private void b33_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(3, 3);
        }

        private void b34_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(3, 4);
        }
        #endregion

        #region Quinta Fila
        private void b40_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(4, 0);
        }

        private void b41_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(4, 1);
        }

        private void b42_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(4, 2);
        }

        private void b43_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(4, 3);
        }

        private void b44_Click(object sender, EventArgs e)
        {
            bloqueoCasilla(4, 4);
        }
        #endregion

        #endregion

        public void imprimirMatriz()
        {
            for(int i = 0; i < tamañoCuadricula; i++)
            {
                for(int j = 0; j < tamañoCuadricula; j++)
                {
                    Console.Write("["+matriz[i,j].getValor()+"]");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < tamañoCuadricula; i++)
            {
                for (int j = 0; j < tamañoCuadricula; j++)
                {
                    Console.Write("[" + matriz[i, j].getPasos() + "]");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void evaluarVecinos(Casilla casilla)
        {
            int posicionI, posicionJ;

            if(casilla.getValor() != 4)
            {
                posicionI = casilla.getPosicionI() - 1;
                posicionJ = casilla.getPosicionJ();
                evaluarCasilla(casilla, posicionI, posicionJ);

                posicionI = casilla.getPosicionI();
                posicionJ = casilla.getPosicionJ() + 1;
                evaluarCasilla(casilla, posicionI, posicionJ);

                posicionI = casilla.getPosicionI() + 1;
                posicionJ = casilla.getPosicionJ();
                evaluarCasilla(casilla, posicionI, posicionJ);

                posicionI = casilla.getPosicionI();
                posicionJ = casilla.getPosicionJ() - 1;
                evaluarCasilla(casilla, posicionI, posicionJ);
            }
            
            openSet.RemoveAt(0);
            closedSet.Add(casilla);
            if(matriz[casilla.getPosicionI(), casilla.getPosicionJ()].getValor() != 4 && matriz[casilla.getPosicionI(), casilla.getPosicionJ()].getValor() != 3)
            {
                panel[casilla.getPosicionI(), casilla.getPosicionJ()].BackColor = Color.FromArgb(139, 0, 0);
            }
        }

        public void evaluarCasilla(Casilla casilla, int posicionI, int posicionJ)
        {
            bool evaluado = false;
            int indiceEvaluado = 0;
            bool espera = false;

            if (posicionI >= 0 && posicionJ >= 0 && posicionI < tamañoCuadricula && posicionJ < tamañoCuadricula && matriz[posicionI, posicionJ].getValor() != 1)
            {
                for (int i = 0; i < closedSet.Count; i++)
                {
                    if (matriz[posicionI, posicionJ].getPosicionI() == closedSet[i].getPosicionI() && matriz[posicionI, posicionJ].getPosicionJ() == closedSet[i].getPosicionJ())
                    {
                        evaluado = true;
                        indiceEvaluado = i;
                        i = closedSet.Count;
                    }
                }

                for(int i = 0; i < openSet.Count; i++)
                {
                    if (matriz[posicionI, posicionJ].getPosicionI() == openSet[i].getPosicionI() && matriz[posicionI, posicionJ].getPosicionJ() == openSet[i].getPosicionJ())
                    {
                        espera = true;
                        i = openSet.Count;
                    }
                }

                if (evaluado == true)
                {
                    if (matriz[posicionI, posicionJ].getPasos() > casilla.getPasos() + 1)
                    {
                        closedSet[indiceEvaluado].setPadre(casilla);
                        closedSet[indiceEvaluado].setPasos(casilla.getPasos() + 1);
                    }
                }
                else if (espera == false)
                {
                    matriz[posicionI, posicionJ].setPadre(casilla);
                    matriz[posicionI, posicionJ].setPasos(casilla.getPasos() + 1);
                    openSet.Add(matriz[posicionI, posicionJ]);
                    if(matriz[posicionI, posicionJ].getValor() != 4 && matriz[posicionI, posicionJ].getValor() != 3)
                    {
                        panel[posicionI, posicionJ].BackColor = Color.FromArgb(34, 139, 34);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            evaluarVecinos(openSet[0]);

            if(openSet.Count == 0)
            {
                for (int i = 0; i < closedSet.Count; i++)
                {
                    if (closedSet[i].getValor() == 4)
                    {
                        camino = closedSet[i];
                        i = closedSet.Count;
                    }
                }

                int contadorIteraciones = 0;
                labelPasos.Text = camino.getPasos().ToString();

                while (camino.getPadre() != null)
                {
                    camino = camino.getPadre();
                    panel[camino.getPosicionI(), camino.getPosicionJ()].BackColor = Color.FromArgb(0, 139, 139);
                    camino.setValor(2);
                    contadorIteraciones++;
                }

                matriz[inicioI, inicioJ].setValor(3);
                panel[inicioI, inicioJ].BackColor = Color.FromArgb(218, 165, 32);
                timer1.Stop();

                if(contadorIteraciones == 0)
                {
                    MessageBox.Show("No existe un camino disponible");
                }
            }
        }
    }
}
