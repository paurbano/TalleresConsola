using System;
using System.Collections;



namespace OReillyFundamentalsDiccionarios
{
    /// <summary>
    /// Este ejemplo muestra el uso de las propiedades Key & Values de una HashTable
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Crear e inicializar una nueva tabla Hash
            Hashtable hashtable = new Hashtable();
            hashtable.Add("123456","Pedro Perez");
            hashtable.Add("76332607", "Pablo Andres");
            hashtable.Add("66783608", "Paola Vidal");
            hashtable.Add("11145724008", "Santiago URbano");

            //Obtener las claves (key) de la tablaHash
            ICollection keys = hashtable.Keys;

            //Obtener los valores (values) de la tablaHash
            ICollection values = hashtable.Values;

            //Recorrer la coleccion de keys y values
            Console.WriteLine("Claves");
            foreach (string key in keys)
            {
                Console.WriteLine("{0}\t,",key);
            }
            Console.WriteLine( );
            Console.WriteLine("Valores");
            foreach (string value in values)
            {
                Console.WriteLine("{0}",value);
            }
        }
    }
}
