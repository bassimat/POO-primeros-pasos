using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Restaurante
{
    public class Carta
    {
        private List<Plato> _platos = new List<Plato>();

    

        public void AgregarPlato( Plato unPlato )
        {
            this._platos.Add( unPlato );
        }

        public bool RemoverPlato( Plato unPlato )
        {
            return this._platos.Remove( unPlato );
        }

        public double GetPrecioPromedio()
        {
            if( this._platos.Count == 0 ) return 0;

            double precioAcumulado = 0;
            foreach (Plato p in this._platos) {
	        	 precioAcumulado += p.GetPrecio();
	        }
            return precioAcumulado/this._platos.Count;
        }

        public Plato GetPlatoMejorOpinion()
        {
            Plato mejorCalificado = null;

            foreach( Plato p in this._platos )
            {
                if( mejorCalificado == null || 
                    p.GetOpinionPromedio() > mejorCalificado.GetOpinionPromedio() )
                    mejorCalificado = p;
            }
            return mejorCalificado;
        }

    }
}
