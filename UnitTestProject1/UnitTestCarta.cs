using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectDLL_Restaurante
{
    [TestClass]
    public class UnitTestCarta
    {

        [TestMethod]
        public void TestCartaAgregarPlatoYObtenerPrecioPromedio()
        {
            DLL_Restaurante.Carta laCarta = new DLL_Restaurante.Carta();
            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Fritas con chedar y panceta", 3 );
            laCarta.AgregarPlato( unPlato );

            Assert.AreEqual( unPlato.GetPrecio(), laCarta.GetPrecioPromedio() );
        }

        [TestMethod]
        public void TestCartaRemoverPlatoYPromedioDePrecioNulo()
        {
            DLL_Restaurante.Carta laCarta = new DLL_Restaurante.Carta();
            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Fritas con chedar y panceta", 3 );
            laCarta.AgregarPlato( unPlato ); 

            double precioPromedio = laCarta.GetPrecioPromedio();
            laCarta.RemoverPlato( unPlato );

            Assert.AreNotEqual( precioPromedio, laCarta.GetPrecioPromedio() );
            Assert.AreEqual( laCarta.GetPrecioPromedio(), 0 );
        }


        [TestMethod]
        public void TestCartaGetPlatoMejorOpinion()
        {
            DLL_Restaurante.Plato mejorPlato = new DLL_Restaurante.Plato( "Risotto de hongos y finas hiervas", 6 );
            mejorPlato.AgregarOpinion( 5 );
            mejorPlato.AgregarOpinion( 4 );
            mejorPlato.AgregarOpinion( 5 );
            mejorPlato.AgregarOpinion( 5 );
            DLL_Restaurante.Plato otroPlato = new DLL_Restaurante.Plato( "Churrasquito premium con rusa", 5 );
            otroPlato.AgregarOpinion( 2 );
            otroPlato.AgregarOpinion( 5 );
            otroPlato.AgregarOpinion( 4 );
            DLL_Restaurante.Carta laCarta = new DLL_Restaurante.Carta();
            laCarta.AgregarPlato( mejorPlato );
            laCarta.AgregarPlato( otroPlato );

            Assert.AreSame( mejorPlato, laCarta.GetPlatoMejorOpinion() );
        }
    }
}
