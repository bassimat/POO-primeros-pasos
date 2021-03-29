using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProjectDLL_Restaurante
{
    [TestClass]
    public class UnitTestPlato
    {

        [TestMethod]
        /// <summary>
        /// Este método genera objetos de tipo <c>Plato</c> a partir de una lista de nombres y prueba su carga satisfactoria.
        /// </summary>
        /// <remarks>
        /// Por cada nombre instancia dos platos, cada uno con un constructor distinto. Luego compara que ambos tengan el mismo nombre que se les cargó.
        /// </remarks>
        public void TestPlato_NombresAmbosConstructores()
        {
            List<string> nombreDePlatos = new List<string>();
            nombreDePlatos.Add( "Milanesas con papas fritas" );
            nombreDePlatos.Add( "Pollo a la parrilla" );
            nombreDePlatos.Add( "Ensalada de rúcula, tomate y queso" );
            nombreDePlatos.Add( "Hamburguesa" );

            DLL_Restaurante.Plato unPlato, mismoPlato;

            for( int i = 0 ; i < nombreDePlatos.Count; i++ )
            {
                unPlato = new DLL_Restaurante.Plato( nombreDePlatos[i], 0 );
                mismoPlato = new DLL_Restaurante.Plato();
                mismoPlato.Nombre = nombreDePlatos[ i ];

                Assert.AreEqual( unPlato.Nombre, mismoPlato.Nombre );
                Assert.AreEqual( unPlato.Nombre, nombreDePlatos[ i ] );
            }
        }


        [TestMethod]
        public void TestPlato_GetPrecioConVariosIngredientes()
        {
            double  precioEsperado = 0;
            int     cantidadDeIngredientes = 4;

            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Hamburguesa completa", cantidadDeIngredientes );

            precioEsperado = DLL_Restaurante.Plato.PRECIO_BASE_PLATO + 
                             DLL_Restaurante.Plato.PRECIO_VARIOS_INGREDIENTES * cantidadDeIngredientes;

            Assert.AreEqual( unPlato.GetPrecio(), precioEsperado );
        }


        [TestMethod]
        public void TestPlato_GetPrecioConPocosIngredientes()
        {
            double  precioEsperado = 0;
            int     cantidadDeIngredientes = 1;

            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Huevo Frito", cantidadDeIngredientes );

            precioEsperado = DLL_Restaurante.Plato.PRECIO_BASE_PLATO + 
                             DLL_Restaurante.Plato.PRECIO_POCOS_INGREDIENTES * cantidadDeIngredientes;

            Assert.AreEqual( unPlato.GetPrecio(), precioEsperado );
        }


        [TestMethod]
        public void TestPlato_GetPrecioSinIngredientes()
        {
            double  precioEsperado = DLL_Restaurante.Plato.PRECIO_BASE_PLATO;
            int     cantidadDeIngredientes = 0;

            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Agua", cantidadDeIngredientes );

            Assert.AreEqual( unPlato.GetPrecio(), precioEsperado );
        }


        [TestMethod]
        public void TestPlato_GetOpinionPromedio()
        {
            double puntajePromedioEsperado = (double)( 5 + 4 + 4 )/ 3;
            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Lomo a la mostaza", 3 );

            unPlato.AgregarOpinion( 5 );
            unPlato.AgregarOpinion( 4 );
            unPlato.AgregarOpinion( 4 );

            Assert.AreEqual( unPlato.GetOpinionPromedio(), puntajePromedioEsperado );
        }


        [TestMethod]
        public void TestPlato_OpinionNulaDaPromedioCero()
        {
            double puntajePromedioEsperado = 0;
            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Rana asada", 1 );

            Assert.AreEqual( unPlato.GetOpinionPromedio(), puntajePromedioEsperado );
        }


        [TestMethod]
        public void TestPlato_CocineroNuloGetMailNoFalla()
        {
            string nombreDelPlato = "Pollo a la parrilla";
            DLL_Restaurante.Plato unPlato = new  DLL_Restaurante.Plato( nombreDelPlato, 5 );
            Assert.IsNotNull( unPlato.GetMailDelCocinero() );
        }


        [TestMethod]
        public void TestPlato_Imprimite()
        {
            string nombreDelPlato = "Pollo a la parrilla";
            string mailDelCocinero = "jorge@yahoo.com";
            DLL_Restaurante.Plato unPlato = new  DLL_Restaurante.Plato( nombreDelPlato, 5 );
            unPlato.Cocinero = new DLL_Restaurante.Cocinero( "Jorge", "Bustos", mailDelCocinero );
            unPlato.AgregarOpinion( 5 );
            unPlato.AgregarOpinion( 3 );

            Assert.AreEqual( unPlato.Imprimite(), nombreDelPlato + " (4 puntos) - " + mailDelCocinero );
        }
    }
}
