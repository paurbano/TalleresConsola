using System;
using System.Threading;

namespace OReillyFundamentalsRetornarValoresDelegadosCompuestos
{
    /// <summary>
    /// Este es un caso en el que un evento retorna un valor, hay que recordar que por convención los eventos encapsulan delegados que retornan void
    /// 
    /// Este ejemplo invoca los métodos "manualmente". Dos clases que instancian un delegado, la primera retorna enteros en secuencia (1,2,3,4,5,..)
    /// la segunda dobla el valor de cada numero(2,4,6,8,10,12,...)
    /// </summary>
    /// 

    public class ClaseConDelegado
    {
        //Delegado compuesto que encapsula un método que retorna un valor entero int
        public delegate int DelegadoQueRetornaInt();
        public DelegadoQueRetornaInt delegado;

        public void Run()
        {
            for (;;)
            {
                //esperar medio segundo
                Thread.Sleep(500);

                //Si hay cambios,Noticar a los suscriptores
                if (delegado != null)
                {
                    //Invocar explicitamente cada método del delegado compuesto en orden apoyandose en el método GetInvocationList
                    //se hace usando foreach, de otra forma solo se mostrarian los valores doblados ya que se sobreescribirian al ejecutarse los metodos
                    foreach(DelegadoQueRetornaInt del in delegado.GetInvocationList())
                    {
                        int resultado = del(); //ejecución métodos delegado
                        Console.WriteLine("Delegado invocado..!! valor retornado :{0}",resultado);
                    }//fin foreach
                }

            }//fin for
        }//fin método Run
    }//fin clase

    public class PrimerSuscriptor
    {
        private int contador=0;
        public void Suscribir(ClaseConDelegado claseCondelegado)
        {
            claseCondelegado.delegado += new ClaseConDelegado.DelegadoQueRetornaInt(MostrarContador);
        }

        public int MostrarContador()
        {
            return ++contador;
        }
    }

    public class SegundoSuscriptor
    {
        private int doble;
        public void Suscribir(ClaseConDelegado claseConDelegado)
        {
            claseConDelegado.delegado += new ClaseConDelegado.DelegadoQueRetornaInt(Doblar);
        }

        public int Doblar()
        {
            return doble += 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClaseConDelegado claseConDelegado = new ClaseConDelegado();

            PrimerSuscriptor ps = new PrimerSuscriptor();
            ps.Suscribir(claseConDelegado);

            SegundoSuscriptor ss = new SegundoSuscriptor();
            ss.Suscribir(claseConDelegado);

            claseConDelegado.Run();
        }
    }
}
