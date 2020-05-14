using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OReillyFundamentalsConversionOperadores
{
    public class Fraction
    {
        private int numerador;
        private int denominador;

        public Fraction(int numerador, int denominador)
        {
            Console.WriteLine("En constructor Fraction (int,int)");
            this.numerador = numerador;
            this.denominador = denominador;
        }
        public Fraction(int NumeroCompleto)
        {
            Console.WriteLine("En constructor Fraction (int)");
            this.numerador = NumeroCompleto;
            this.denominador = 1;
        }

        public static implicit operator Fraction(int theInt)
        {
            Console.WriteLine("En Conversión implicita de Fracción");
            return new Fraction(theInt);
        }

        public static explicit operator int(Fraction theFraction)
        {
            Console.WriteLine("En conversión explicita a int");
            return theFraction.numerador / theFraction.denominador;
        }

        public static bool operator ==(Fraction lhs, Fraction rhs)
        {
            Console.WriteLine("En operador ==");
            if (lhs.numerador == rhs.numerador && lhs.denominador == rhs.denominador)
            {
                return true;
            }

            //aqui código para tratar fracciones no gratas!

            return false;
        }

        public static bool operator !=(Fraction lhs, Fraction rhs)
        {
            Console.WriteLine("En operador !=");
            return !(lhs == rhs);

        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("En método Equals()");
            if (!(obj is Fraction))
            {
                return false;
            }

            return this == (Fraction)obj;
        }

        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            Console.WriteLine("En operador +");
            if (lhs.denominador == rhs.denominador)
            {
                return new Fraction(lhs.numerador + rhs.numerador, lhs.denominador);
            }

            int firstProduct = lhs.numerador * rhs.denominador;
            int secondProduct = rhs.numerador * lhs.denominador;

            return new Fraction(firstProduct + secondProduct, lhs.denominador * rhs.denominador);
        }

        public override string ToString()
        {
            String s = numerador.ToString() + "/" + denominador.ToString();
            return s;
        }

        public class Tester
        {
            static void Main()
            {
                Fraction f1 = new Fraction(3, 4);
                Console.WriteLine("Fraccion f1:{0}", f1.ToString());

                Fraction f2 = new Fraction(2, 4);
                Console.WriteLine("Fracción f2:{0}", f2.ToString());

                Fraction f3 = f1 + f2;
                Console.WriteLine("f1+f2=f3 {0}", f3.ToString());

                Fraction f4 = f3 + 5;
                Console.WriteLine("f3+5=f4 {0}", f4.ToString());

                Fraction f5 = new Fraction(2, 4);

                if (f2 == f5)
                {
                    Console.WriteLine("F5:{0}==F2:{1}", f5.ToString(), f2.ToString());
                }
            }
        }
    }
}
