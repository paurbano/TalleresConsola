using System;
using System.Threading;

namespace OReillyFundamentalsEventos
{
    /// <summary>
    /// Este ejemplo crea 2 clases MostarReloj y LogHoraActual --suscriptores--, ambas se suscriben a un evento de una tercera clase --publicador-- (Reloj.OnSecondChange)
    /// 
    /// OnSecondChange es un delegado compuesto. Inicia en null
    /// 
    /// Cuando las clases observadoras(MostarReloj y LogHoraActual) desean ser notificadas, crean una instancia del delegado y adicionan este a OnSecondChange
    /// </summary>

    //clase que contiene la información del evento, hereda de EventArgs
    //indica que va a generar un objeto para el segundo parámetro del manejador de evento
    public class TimeInfoEventArgs : EventArgs
    {
        public readonly int hora;
        public readonly int minuto;
        public readonly int segundo;
              
        public TimeInfoEventArgs(int hora, int minuto, int segundo)
        {
            this.hora = hora;
            this.minuto = minuto;
            this.segundo = segundo;
        }
    }

    //El objetivo de esta clase es que la observen otras clases
    //Esta clase pública un delegado: OnSecondChange
    public class Reloj
    {
        private int hora;
        private int segundo;
        private int minuto;

        //Delegado que los suscritos deben implementar
        public delegate void SecondChangeHandler(object reloj,TimeInfoEventArgs informacionTiempo);
        
        //Instanciación delegado a publicar -- creación evento OnSecondChange
        //La palabra reservada event controla el acceso al delegado
        public event SecondChangeHandler OnSecondChange;

        //Poner a correr el reloj
        //Lanzará un evento cada segundo
        public void Run()
        {
            //Ciclo infinito
            for (;;)
            {
                //Pausa de 10 milisegundos
                Thread.Sleep(10);

                //Obtener la hora actual
                System.DateTime dt = System.DateTime.Now;

                //Si el segundo cambia notifica a los suscriptores
                if (dt.Second != segundo)
                {
                    //Crear el objeto TimeInfoEventArgs y
                    //pasarlo a los suscriptores
                    TimeInfoEventArgs informacionTiempo = new TimeInfoEventArgs(dt.Hour,dt.Minute,dt.Second);

                    //si alguien se ha suscrito, se le(s) notifica
                    if (OnSecondChange != null)
                    {
                        OnSecondChange(this, informacionTiempo);
                    }
                }
                //Actualiza los valores de hora,minuto y segundo
                this.segundo = dt.Second;
                this.minuto = dt.Minute;
                this.hora = dt.Hour;
            }// fin for
            
        }
    }

    //Un observador(Observer). MostarReloj se suscribe al evento (OnSecondChange) del Reloj
    //La tarea de MostrarReloj es presentar la hora actual
    public class MostrarReloj
    {
        //Suscribirse al evento
        //Dado un Reloj, suscribirse a su evento SecondChangeHandler
        public void Suscribir(Reloj reloj)
        {
            //Aqui se define que es un delegado compuesto por la operación +=
            reloj.OnSecondChange += new Reloj.SecondChangeHandler(HoraACambiado);

        }

        //Método que implementa la funcionalidad del delegado. Imprimir la hora!! 
        public void HoraACambiado(object reloj,TimeInfoEventArgs ti)
        {
            Console.WriteLine("Hora Actual {0}:{1}:{2}",ti.hora.ToString(),ti.minuto.ToString(),ti.segundo.ToString());
        }
    }

    //Un segundo observador - suscriptor
    //Su tarea es escribir a un "archivo"
    public class LogHoraActual
    {
        //Suscribirse al evento
        //SecondChangeHandler
        public void Suscribir(Reloj reloj)
        {
            //Aqui se define que es un delegado compuesto por la operación +=
            reloj.OnSecondChange += new Reloj.SecondChangeHandler(EscribirEntradaLog);
        }

        public void EscribirEntradaLog(object reloj, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Registrando en archivo:{0}:{1}:{2}", ti.hora.ToString(), ti.minuto.ToString(), ti.segundo.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Crear un nuevo reloj -- publicador
            Reloj reloj = new Reloj();

            //Crear el mostrador y decirle que suscriba al reloj
            MostrarReloj mr = new MostrarReloj();
            mr.Suscribir(reloj);


            //Crear un objeto Log y decirle que se suscriba al reloj
            LogHoraActual horaActual = new LogHoraActual();
            horaActual.Suscribir(reloj);
            
            //Poner a andar el reloj
            reloj.Run();
        }
    }
}
