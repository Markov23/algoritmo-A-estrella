using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoAEstrella.ClasesAuxiliares
{
    public class Casilla
    {
        private int pasos;
        private int valor;
        private Casilla padre;
        private int posicionI;
        private int posicionJ;

        public Casilla()
        {
            this.pasos = 0;
            this.valor = 0;
            this.padre = null;
            this.posicionI = 0;
            this.posicionJ = 0;
        }

        public Casilla(int pasos, int valor, int posicionI, int posicionJ)
        {
            this.pasos = pasos;
            this.valor = valor;
            this.padre = null;
            this.posicionI = posicionI;
            this.posicionJ = posicionJ;
        }

        public Casilla(int pasos, int valor, Casilla padre, int posicionI, int posicionJ)
        {
            this.pasos = pasos;
            this.valor = valor;
            this.padre = padre;
            this.posicionI = posicionI;
            this.posicionJ = posicionJ;
        }

        public int getPasos()
        {
            return this.pasos;
        }

        public void setPasos(int pasos)
        {
            this.pasos = pasos;
        }

        public int getValor()
        {
            return this.valor;
        }

        public void setValor(int valor)
        {
            this.valor = valor;
        }

        public Casilla getPadre()
        {
            return this.padre;
        }

        public void setPadre(Casilla padre)
        {
            this.padre = padre;
        }

        public int getPosicionI()
        {
            return this.posicionI;
        }

        public void setPosicionI(int posicionI)
        {
            this.posicionI = posicionI;
        }

        public int getPosicionJ()
        {
            return this.posicionJ;
        }

        public void setPosicionJ(int posicionJ)
        {
            this.posicionJ = posicionJ;
        }
    }
}
