#define DEBUG

using System;

namespace OReillyFundamentalsExceptions
{
    /// <summary>
    /// Manejo de excepciones 
    /// 
    /// </summary>
    public class Test
    {
        static void Main(string[] args)

        {
            #if DEBUG
                Console.WriteLine("Iniciando Main...");
                Test t = new Test();
                //Para probar las excepciones de división
                t.TestFunc();
                Console.WriteLine("Saliendo de Main..");
            #else
                t.Funcion1();
                
            #endif

        }

        //definición básica de una excepción generica y como capturarla
        // bloque try{} catch{}
        public void Funcion1()
        {
            Console.WriteLine("Inicio Funcion1");
            Funcion2();
           
            Console.WriteLine("Saliendo Funcion1");

        }
        public void Funcion2()
        {
            Console.WriteLine("Inicio Funcion2");
            //probar moviendo este bloque a la función1
            try
            {
                Console.WriteLine("Iniciando bloque Try");
                throw new System.Exception();
                Console.WriteLine("Saliendo bloque Try");
            }
            catch (Exception)
            {
                Console.WriteLine("Excepción capturada y manejada");
                //throw;
            }
                       
            Console.WriteLine("Saliendo Funcion2");
        }

        //Especificación de las excepciones
        ////Divisón de dos números y manejar las posibles excepciones

        public void TestFunc()
        {
            try
            {
                double numerador = 0;
                double denominador = 2;
                Console.WriteLine("División: {0}/{1}={2}", numerador, denominador, Division(numerador, denominador));
            }
            catch (System.DivideByZeroException)
            {
                Console.WriteLine("Excepción División por Cero, capturada!!");
            }
            catch (System.ArithmeticException)
            {
                Console.WriteLine("Excepción aritmetica, capturada!!!");
            }
            catch
            {
                Console.WriteLine("Excepción generica capturada!!!");
            }
            finally
            {
                Console.WriteLine("Finally, siempre se ejecuta, apesar de haberse lanzado una excepción");
            }
        }

        public double Division(double numerador, double denominador)
        {
            if (denominador == 0)
                throw new System.DivideByZeroException();
            if (numerador == 0)
                throw new System.ArithmeticException();

            return numerador / denominador;
        }
    }
}
