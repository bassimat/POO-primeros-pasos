using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Restaurante
{
    class Opinion
    {
        private const int PUNTAJE_MAXIMO = 5;
        private List<int> _puntajes = new List<int>();

        public void AgregarOpinion( int unPuntaje )
        {
            if ( unPuntaje < 0 || unPuntaje > PUNTAJE_MAXIMO )
                throw new ArgumentOutOfRangeException();

            this._puntajes.Add( unPuntaje );
        }

        public double GetOpinionPromedio()
        {
            if ( this._puntajes.Count == 0 ) return 0;
                
            double puntajeAcumulado = 0;
            foreach (int puntaje in this._puntajes) {
		        puntajeAcumulado += puntaje;
            }
            return puntajeAcumulado/this._puntajes.Count;
	    }
    }
}
