using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OReillyFundamentalsExcepcionesPersonalizadas
{
    /// <summary>
    /// Excepciones personalizadas
    /// Clase que deriva de ApplicationException, recibe la cadena del mensaje
    /// e invoca al constructor base
    /// </summary>
    public class MiExcepcion : System.ApplicationException
    {
        public MiExcepcion(string mensaje)
            : base(mensaje)
        {

        }
    }
    
    public class Test
    {
        static void Main(string[] args)
        {
            #if DEBUG
            Console.WriteLine("Iniciando Main...");
            Test t = new Test();
            t.TestFunc();
            Console.WriteLine("Saliendo de Main..");
            #else
            
                
            #endif
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
            catch (System.DivideByZeroException e)
            {
                Console.WriteLine("Excepción División por Cero, capturada!!:{0}",e.Message);
                Console.WriteLine("\tEnlace:{0}", e.HelpLink);
            }
            catch (MiExcepcion e) //uso de la excepción personalizada
            {
                Console.WriteLine("Excepción personalizada, capturada!!!:{0}",e.Message);
                Console.WriteLine("\tEnlace:{0}", e.HelpLink);
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
            { 
                DivideByZeroException e=new DivideByZeroException();
                e.HelpLink = "http://www.excepcionespersonalizadas.com";
                throw e;
            }
            if (numerador == 0)
            {
                // instanciar y definir Excepción personalizada
                MiExcepcion e = new MiExcepcion("Numerador 0 o nulo, resultado Divisón 0");
                e.HelpLink = "http://www.excepcionespersonalizadas.com";
                throw e;
            }

            return numerador / denominador;
        }
    }
}
