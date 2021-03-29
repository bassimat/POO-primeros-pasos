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
        private int         _precioBase;

        public Plato()
        {
        }

        public Plato( string nombre, int cantidadDeIntegrantes )
        {
            this._nombre = nombre;
            this._cantIngred = cantidadDeIntegrantes;
        }



        public Cocinero Cocinero
        {
            get;
            set;
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
            string str = this._nombre + " " + "(7 puntos)" + " - " + this.GetMailDelCocinero();
            return str;
        }

    }
}
