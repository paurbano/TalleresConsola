using System;
using System.Collections;

namespace OReillyFundamentalsDiccionariosTodoJunto
{
    /// <summary>
    /// Uso de la interface IDictionaryEnumerator, para enumerar un objeto IDictionary
    /// provee propiedades para acceder simultaneamente a las claves(keys) y valores(values) para cada item en el diccionario
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Crear e inicializar una nueva tabla Hash
            Hashtable hashtable = new Hashtable();

            hashtable.Add("123456", "Pedro Perez");
            hashtable.Add("76332607", "Pablo Andres");
            hashtable.Add("66783608", "Paola Vidal");
            hashtable.Add("11145724008", "Santiago URbano");

            // Mostrar las propiedades y valores de la tabla hash.
            Console.WriteLine("Tabla hash");
            Console.WriteLine("  Cantidad:    {0}", hashtable.Count);
            Console.WriteLine("  Keys & Values:");
            ImprimirKeysAndValues(hashtable);

        }

        public static void ImprimirKeysAndValues(Hashtable tabla)
        {
            IDictionaryEnumerator enumerador = tabla.GetEnumerator();
            while (enumerador.MoveNext())
                Console.WriteLine("\t{0}:\t{1}",enumerador.Key,enumerador.Value);
            Console.WriteLine();
        }
    }
}
