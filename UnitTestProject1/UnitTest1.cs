using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        /// <summary>
        /// Este método genera objetos de tipo <c>Plato</c> a partir de una lista de nombres y prueba su carga satisfactoria.
        /// </summary>
        /// <remarks>
        /// Por cada nombre instancia dos platos, cada uno con un constructor distinto. Luego compara que ambos tengan el mismo nombre que se les cargó.
        /// </remarks>
        public void TestNombresDePlatos()
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
        public void TestPrecioConVariosIngredientes()
        {
            double  precioEsperado = 0;
            int     cantidadDeIngredientes = 4;

            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Hamburguesa completa", cantidadDeIngredientes );

            precioEsperado = DLL_Restaurante.Plato.PRECIO_BASE_PLATO + 
                             DLL_Restaurante.Plato.PRECIO_VARIOS_INGREDIENTES * cantidadDeIngredientes;

            Assert.AreEqual( unPlato.GetPrecio(), precioEsperado );

        }


        [TestMethod]
        public void TestPrecioConPocosIngredientes()
        {
            double  precioEsperado = 0;
            int     cantidadDeIngredientes = 1;

            DLL_Restaurante.Plato unPlato = new DLL_Restaurante.Plato( "Omelette", cantidadDeIngredientes );

            precioEsperado = DLL_Restaurante.Plato.PRECIO_BASE_PLATO + 
                             DLL_Restaurante.Plato.PRECIO_POCOS_INGREDIENTES * cantidadDeIngredientes;

            Assert.AreEqual( unPlato.GetPrecio(), precioEsperado );

        }
    }
}
