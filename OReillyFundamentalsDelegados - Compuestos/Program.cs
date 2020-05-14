using System;

namespace OReillyFundamentalsDelegados___Compuestos
{
    //Este ejemplo muestra cómo componer delegados. Una propiedad útil de los objetos delegados es que se pueden componer mediante el operador "+". 
    //Un delegado compuesto llama a los delegados de los que se compone. Solo pueden ser compuestos los delegados del mismo tipo.
    //El uso de los delegados es mejor ententido en términos de eventos. 

    //Declaración delegado
    public delegate void DelegadoCadena(string s);

    public class MiclaseImplementadora
    {
        public static void EscribeCadena(string s)
        {
            Console.WriteLine("Escribiendo Cadena {0}",s);
        }

        public static void LogCadena(string s)
        {
            Console.WriteLine("Registrando Cadena {0}", s);
        }

        public static void TransmitirCadena(string s)
        {
            Console.WriteLine("Transmitiendo Cadena {0}", s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Definir Objetos tipo delegado
            DelegadoCadena Escribir, Log, Transmitir,DelegadoMultiple;

            //Instanciar los 3 primeros delegados ,pasando los métodos a encapsular de la clase "MiclaseImplementadora"
            Escribir = new DelegadoCadena(MiclaseImplementadora.EscribeCadena);
            Log = new DelegadoCadena(MiclaseImplementadora.LogCadena);
            Transmitir = new DelegadoCadena(MiclaseImplementadora.TransmitirCadena);


            //Invocar el método delegado Escritura
            Escribir("Pasada al Escritor \n");

            //Invocar el método delegado Log
            Log("Pasada al Log\n");

            //Invocar el método delegado Transmisión
            Transmitir("Pasada al transmisor \n");

            //Presentar al usuario mensaje informando que va a combinar 2 delegados en uno solo
            Console.WriteLine("DelegadoMultiple=Escribir+Log");

            //Combinar los 2 delegados y asignarlos al DelegadoMultiple
            DelegadoMultiple = Escribir + Log;

            DelegadoMultiple(":Primera cadena pasada al Collector");

            //Informar que se va adicionar un tercer delegado 
            Console.WriteLine("\nDelegadoMultiple+=Transmitir");

            //Adicionar el tercer delegado
            DelegadoMultiple += Transmitir;

            //Invocar el método con los tres delegados 
            DelegadoMultiple(":Segunda cadena pasada al Colector");

            //Informar que se va a remover el delegado Registrar
            Console.WriteLine("\nDelegadoMultiple-=Log");

            //Remover el delegado Log del delegado Multiple
            DelegadoMultiple -= Log;

            //Invocar los dos métodos restantes
            DelegadoMultiple(":Tercera cadena pasada al Colector");
        }
    }
}
