//Uso de indexador dentro de una clase.
//Hay ocaciones en las que es deseable acceder a una colección dentro de una clase, como si la clase en si misma fuera un arrelo.
//Un indexador es un contructor de C# que le permite acceder a colecciones contenidas por una clase usando la sintaxis de arreglos <<[]>>.
//Un indexador es una clase especial de propiedad e incluye métodos Get() y Set() para especificar su comportamiento.
//Aunque es comun usar enteros como valores de indice, se puede indexar una colección sobre otros tipos de datos, incluyendo cadenas.

//Para declarar una propiedad indexadora dentro de una clase se usa la siguiente sintaxis:
//tipo this [tipo argumento] {get,set;}


using System;

namespace OReillyFundamentalsIndexadores
{
    //Simular un Control listBox sencillo
    public class ListBoxTest
    {
        private string[] strings;
        private int contador=0;

        //COnstructor recibe el arreglo de cadenas del control
        public ListBoxTest(params string[] cadenasIniciales)
        {
            //Abre espacio para las cadenas
            strings = new string[256];

            //copia las cadenas pasadas al constructor
            foreach (string s in cadenasIniciales)
            {
                strings[contador++] = s;
            }
           
        }

        //Adiciona una cadena al final de listBox
        public void Add(String cadena)
        {
            if (contador >= strings.Length)
            {
                throw new System.Exception();
            }
            else
                strings[contador++] = cadena;
        }

        private int encuentraCadenas(string buscarCadena)
        {
            for (int i = 0; i < strings.Length;i++ )
            {
                if (strings[i].StartsWith(buscarCadena))
                    return i;
            }
            return -1;
        }

        //Método indexador, sin nombre, por lo tanto usa la palabra reservada <<this>> para identificarlo
        //Da acceso al arreglo mediante un indice numérico
        public string this[int index]
        {
            get
            {
                if (index < 0 || index > strings.Length)
                {
                    throw new System.Exception("Indice esta fuera de los limites del arreglo..");
                }
                return strings[index];
            }
            set
            {
                if (index > strings.Length)
                {
                    throw new System.Exception("Indice es mayor que el tamaño del arreglo..");
                }
                else
                    strings[index] = value;
            }
        }

        //Indice sobre cadenas
        public string this[string index]
        {
            get
            {
                if (index.Length == 0)
                {
                    throw new System.Exception("Cadena vacia...");
                }
                else
                    return this[encuentraCadenas(index)];
            }
            set
            {
                strings[encuentraCadenas(index)] = value;
            }
        }

        //Cuantas cadenas tiene el control
        public int GetEntries()
        {
            return contador;
        }
    }// fin ListBoxTest

    public class Tester 
    {
        static void Main()
        {
            //Crea un objeto del tipo ListBoxTest y lo inicializa con 2 cadenas
            ListBoxTest lbt = new ListBoxTest("Hola","Mundo");

            //agrega unas cuantas usando el método publico <<Add>> de la clase
            lbt.Add("Loro");
            lbt.Add("que");
            lbt.Add("repite");
            lbt.Add("Todo");
            lbt.Add("Lo");
            lbt.Add("Que");
            lbt.Add("Dice");
            lbt.Add("la gente!");

            //verificar el acceso al arreglo
            string cadena = "El";
            lbt[0] = "Soy";
            lbt[1] = cadena;
            lbt["la"]="agente!";
            //lbt["abc"] = "e pica"; //probar y hacer cambio para tratar correctamente cuando no se encuentra la cadena

            for (int i = 0; i < lbt.GetEntries();i++ )
            {
                Console.WriteLine("lbt[{0}]:{1}",i,lbt[i]);
            }

        }// fin main()
    } //fin TEster
} // fin namespace
