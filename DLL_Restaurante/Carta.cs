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

        public Cocinero GetCocineroPrincipal()
        {
            if( this._platos.Count == 0 ) throw new NullReferenceException();

            Dictionary<Cocinero,int> cantPlatosPorCocinero = new Dictionary<Cocinero,int>();

            foreach( Plato p in this._platos )
            {
                if( p.Cocinero != null )
                {
                    if( cantPlatosPorCocinero.ContainsKey( p.Cocinero ) )
                        cantPlatosPorCocinero[ p.Cocinero ]++;
                    else
                        cantPlatosPorCocinero.Add( p.Cocinero, 1 );
                }
            }
            if( cantPlatosPorCocinero.Count == 0 ) throw new NullReferenceException();

            KeyValuePair<Cocinero,int> cocineroConMasPlatos = new KeyValuePair<Cocinero,int>();
            bool primerElemento = true;
            foreach( KeyValuePair<Cocinero,int> kvp in cantPlatosPorCocinero )
            {
                if( primerElemento || kvp.Value > cocineroConMasPlatos.Value )
                {
                    cocineroConMasPlatos = kvp;
                    primerElemento = false;
                }
            }
            return cocineroConMasPlatos.Key;
        }
    }
}
