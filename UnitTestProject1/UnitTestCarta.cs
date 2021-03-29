using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectDLL_Restaurante
{
    [TestClass]
    public class UnitTestCarta
    {

        [TestMethod]
        public void TestCarta_AgregarPlatoYObtenerPrecioPromedio()
        {
            DLL_Restaurante.Carta laCarta = new DLL_Restaurante.Carta();
            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Fritas con chedar y panceta", 3 );
            laCarta.AgregarPlato( unPlato );

            Assert.AreEqual( unPlato.GetPrecio(), laCarta.GetPrecioPromedio() );
        }

        [TestMethod]
        public void TestCarta_RemoverPlatoYPromedioDePrecioNulo()
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
        public void TestCarta_GetPlatoMejorOpinion()
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


        [TestMethod]
        public void TestCarta_GetCocineroPrincipal()
        {
            DLL_Restaurante.Carta laCarta = new DLL_Restaurante.Carta();

            DLL_Restaurante.Cocinero cheff1 = new DLL_Restaurante.Cocinero() {Nombre = "Armando",    Apellido = "Quito",   Mail = "armandoestebanquito@gmail.com"};
            DLL_Restaurante.Cocinero cheff2 = new DLL_Restaurante.Cocinero() {Nombre = "Victoria",   Apellido = "Ahumada", Mail = "vahumada@live.com.ar"};
            DLL_Restaurante.Cocinero cheff3 = new DLL_Restaurante.Cocinero() {Nombre = "Juan Pablo", Apellido = "Blanco",  Mail = "jpblanco@yahoo.com"};

            // El cocinero principal sera el que mas platos tenga. En caso de empate, resulta principal el que haya ingresado su plato primero
            DLL_Restaurante.Cocinero cocineroPrincipal = cheff3; // 4 platos y primer ingreso: "Pollo a la parrilla"

            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Milanesas con papas fritas", 4 , cheff1 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Pollo a la parrilla", 2 , cheff3 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Ensalada de rúcula, tomate y queso", 4 , cheff2 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Hamburguesa", 3 , cheff1 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Hamburguesa completa", 5 , cheff3 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Huevo Frito", 1 , cheff1 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Agua", 0 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Lomo a la mostaza", 3 , cheff2 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Rana asada", 1 , cheff2 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Fritas con chedar y panceta", 3 , cheff3 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Risotto de hongos y finas hiervas", 6 , cheff2 ) );
            laCarta.AgregarPlato( new DLL_Restaurante.Plato( "Churrasquito premium con rusa", 5 , cheff3 ) );

            Assert.AreEqual( cocineroPrincipal, laCarta.GetCocineroPrincipal() );
        }
    }
}
