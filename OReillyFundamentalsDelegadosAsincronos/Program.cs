using System;
using System.Threading;

namespace OReillyFundamentalsDelegadosAsincronos
{
    /// <summary>
    /// Este ejemplo es una modificación del ejercicio de retornar valores con delegados, haciendo que los métodos se ejecuten de manera asíncrona;
    /// esto es se invoca(n) el/los método(s) delegados y poder continuar con otros procesos sin esperar a que estos terminen y den su resultado.
    /// 
    /// Para hacer esta tarea de; entregar una tarea y ser notificado cuando esta este terminada, se implementa usando un Delegado. .Net  provee un 
    /// mecanisno de respuesta definiendo el delegado ASyncCallBack:
    /// 
    /// public delegate void ASyncCallBack(IAsyncResult ar);
    /// 
    /// El efecto de esto es, que se registran los métodos en el orden PrimerSuscriptor.MostrarContador y SegundoSuscriptor.Doblar, pero se 
    /// "llaman/invocan/corren/ejecutan" asíncronamente, por lo tanto no hay espera entre la llamada al primero esperar a que termine y llamar 
    /// al segundo.
    /// 
    /// Cuando MostrarContador o Doblar tengan un resultado, el método de respuesta "ValoresDevueltos" es invocado, y se usa el objeto IAsyncResult pasado
    /// como parámetro para obtener el resultado de esos métodos mediante una conversión al tipo del delegado original
    /// 
    /// </summary>
    public class ClaseConDelegado
    {
        //Delegado compuesto que encapsula un método que retorna un valor entero int
        public delegate int DelegadoQueRetornaInt();
        public DelegadoQueRetornaInt delegado;

        public void Run()
        {
            for (; ; )
            {
                //esperar medio segundo
                Thread.Sleep(500);

                //Si hay cambios,Noticar a los suscriptores
                if (delegado != null)
                {
                    //Invocar explicitamente cada método del delegado compuesto en orden apoyandose en el método GetInvocationList
                    
                    foreach (DelegadoQueRetornaInt del in delegado.GetInvocationList())
                    {
                        //Cambio con respecto a retornar valores con delegados
                        
                        //La Invocación asincrona se hace con BeginInvoke, este recibe 2 parámetros:
                        //              El primero es un delegado de tipo AsyncCallback
                        //              El segundo es nuestro delegado del método encapsulado que se quiere ejecutar

                        //Pasa el delegado como el estado de un objeto 
                        del.BeginInvoke(new AsyncCallback(ValoresDevueltos), del);

                        //int resultado = del(); //ejecución métodos delegado
                        //Console.WriteLine("Delegado invocado..!! valor retornado :{0}", resultado);
                    }//fin foreach
                }

            }//fin for
        }//fin método Run

        //Método de respuesta que captura y muestra los resultados
        public void ValoresDevueltos(IAsyncResult iar)
        {
            //Convierte el objeto iar devuelta al tipo de nuestro delegado
            DelegadoQueRetornaInt del = (DelegadoQueRetornaInt)iar.AsyncState;

            //Llama a EndInvoke() en el delegado para obtener los resultado
            int resultado = del.EndInvoke(iar);

            //Muestra el resultado del método
            Console.WriteLine("Delegado invocado..!! valor retornado :{0}", resultado);         
        }
    }//fin clase

    public class PrimerSuscriptor
    {
        private int contador = 0;
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
