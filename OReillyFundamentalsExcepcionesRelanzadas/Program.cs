using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OReillyFundamentalsExcepcionesRelanzadas
{
    //hacer un paso a paso ejecutando el depurador, para ver en detalle la secuencia
    public class MiExcepcion : System.ApplicationException
    {
        public MiExcepcion(string mensaje,Exception inner)
            : base(mensaje,inner)
        {

        }
    }

    public class Prueba
    {
        static void Main(string[] args)
        {
            Prueba p = new Prueba();
            p.FuncionPrueba();
        }

        public void FuncionPrueba()
        {
            //se capturan las excepciones lanzadas
            try
            {
                Funcion1();
            }
            catch (MiExcepcion e)
            {
                Console.WriteLine("\n{0}",e.Message);
                Console.WriteLine("Trayendo historial de excepciones");
                Exception inner = e.InnerException;
                //se despliegan las excepciones internas 
                while(inner!=null)
                {
                    Console.WriteLine("{0}",inner.Message);
                    inner=inner.InnerException;
                }
                
            }
        }

        public void Funcion1()
        {
            try
            {
                Funcion2();
            }
            catch (Exception e)
            {
                //se captura la excepción igual que en función2 se crea una nueva de tipo MiExcepcion y la original "e" 
                //se convierte en una excepción interna de DivideByZeroException(E1)
                //todo lo anterior se lanza a FuncionPrueba
                MiExcepcion ex = new MiExcepcion("E3 - Excepción personalizada!",e);
                throw ex;
            }
        }

        public void Funcion2()
        //Captura la excepción de función 3, toma alguna acciones correctivas y lanza una nueva excepción

        {
            try
            {
                Funcion3();
            }
            catch (System.DivideByZeroException e)
            {
                //Pasa un mensaje personalizado y la excepción original "e", de esta forma la excepción original se convierte en InnerException
                //para E2 y la lanza a Funcion1
                Exception ex = new Exception("E2 - Función 2, división por cero controlada", e);
                throw ex;
            }
        }

        public void Funcion3()
        {
            try
            {
                Funcion4();
            }
            catch (System.ArithmeticException)
            {
                //Captura la excepción de función4
                //No toma ninguna acción, solo relanza la misma excepción sin ninguna modificación
                throw;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Excepción en función 3 controlada aquí");
            }
        }

        public void Funcion4()
        {
            throw new DivideByZeroException("E1 - Excepción, División por Cero");
        }
    
    }

}   
