using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Program
    {
        static void Main( string[] args )
        {

            DLL_Restaurante.Plato unPlato = new  DLL_Restaurante.Plato("Pollo a la parrilla", 5 );
            unPlato.Cocinero = new DLL_Restaurante.Cocinero( "Jorge", "Bustos", "jorge@yahoo.com" );

            Console.WriteLine( unPlato.ToString() );
            Console.ReadKey();
        }
    }
}
