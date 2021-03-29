using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Restaurante
{
    public class Cocinero
    {
        private string _nombre;
        private string _apellido;
        private string _mail;

        public Cocinero()
        {
        }

        public Cocinero( string nombre, string apellido, string mail = "" )
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
        }


        public string Nombre
        {
            get{ return this._nombre; }
            set{ this._nombre = value; }
        }
        
        public string Apellido
        {
            get{ return this._apellido; }
            set{ this._apellido = value; }
        }
        
        public string Mail
        {
            get{ return this._mail; }
            set{ this._mail = value; }
        }

        public override string ToString()
        {
            string str = this.Nombre +" "+ this.Apellido +" ("+ this.Mail +")";
            return str;
        }
    }
}
