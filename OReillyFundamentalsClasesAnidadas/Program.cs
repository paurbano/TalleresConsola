using System;

namespace OReillyFundamentalsClasesAnidadas
{
    /// <summary>
    /// En ocaciones la clase contenida puede existir solo para ayudar a la clase externa. actua como clase auxiliar.
    /// y no hay razon para que sea visible o publica a otras
    /// </summary>
    public class Fraccion
    {
        private int numerador;
        private int denominador;

        public Fraccion(int pNumerador, int pDenominador)
        {
            numerador = pNumerador;
            denominador = pDenominador;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}",numerador,denominador);
        }

        //Clase anidada
        //Tiene acceso a los miembros privados de la clase -> f.numerador, f.denominador
        //Esto es posible por que es una clase anidada, de lo contrario no se podria
        internal class ElementosFraccion
        {
            public void DrawFraccion(Fraccion f)
            {
                Console.WriteLine("Numerador:{0}",f.numerador);
                Console.WriteLine("Denominador:{0}", f.denominador);
            }
        }
    }

    public class Tester {
        static void Main()
        {
            Fraccion f1 = new Fraccion(3, 4);
            Console.WriteLine("Fracción:{0}",f1.ToString());

            //Creación objeto clase anidada
            Fraccion.ElementosFraccion fa = new Fraccion.ElementosFraccion();
            fa.DrawFraccion(f1);
        }
}

}
