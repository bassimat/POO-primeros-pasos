using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Restaurante
{
    public class Plato
    {
        private string      _nombre;
        private int         _cantIngred;
        private int         _precioBase = PRECIO_BASE_PLATO;
        public Cocinero     Cocinero {
                                    get;
                                    set;
                            }

        public const int    PRECIO_BASE_PLATO = 300;
        public const int    CANTIDAD_POCOS_INGREDIENTES = 3;
        public const double PRECIO_POCOS_INGREDIENTES = 30;
        public const double PRECIO_VARIOS_INGREDIENTES = 20;

        public Plato()
        {
        }

        public Plato( string nombre, int cantidadDeIntegrantes )
        {
            this._nombre = nombre;
            this._cantIngred = cantidadDeIntegrantes;
        }


        public string Nombre
        {
            get{ return this._nombre;}
            set{ this._nombre = value;}
        }

        public int CantidadDeIngredientes
        {
            get{ return this._cantIngred;}
            set{ this._cantIngred = value;}
        }


        public double GetPrecio()
        {
            double precioFinal = this._precioBase;

            if( this.CantidadDeIngredientes > CANTIDAD_POCOS_INGREDIENTES )
                precioFinal += this.CantidadDeIngredientes * PRECIO_VARIOS_INGREDIENTES;
            else
                precioFinal += this.CantidadDeIngredientes * PRECIO_POCOS_INGREDIENTES;

            return precioFinal;
        }

        public string GetMailDelCocinero()
        {
            if( null == this.Cocinero )
                return String.Empty;
            else
                return this.Cocinero.Mail;
        }

        public override string ToString()
        {
            // HACK: Tomar los puntos de opinion del método en cuestión cuando se integre el ejercicio 2.
            string str = this._nombre + " " + "(4 puntos)" + " - " + this.GetMailDelCocinero();
            return str;
        }

        public string Imprimite()
        {
            return this.ToString();
        }

    }
}
