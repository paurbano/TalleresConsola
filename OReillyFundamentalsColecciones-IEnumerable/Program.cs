using System;
using System.Collections;

namespace OReillyFundamentalsColecciones_IEnumerable
{
    /// <summary>
    /// Uso de la interface IEnumerable
    /// </summary>
    public class ListBoxTest:IEnumerable 
    {
        private string[] strings;
        private int contador = 0;

        //Constructor recibe el arreglo de cadenas del control
        public ListBoxTest(params string[] cadenasIniciales)
        {
            //Abre espacio para las cadenas
            strings = new string[20];

            //copia las cadenas pasadas al constructor
            foreach (string s in cadenasIniciales)
            {
                strings[contador++] = s;
            }

        }

        //Cuando se implementa IEnumerable, también se debe implementar IEnumerator
        //Implementación privada de ListBoxEnumerator
        //IEnumerator : Apoya la iteración sobre una colección no genérica
        private class ListBoxEnumerator:IEnumerator
        {
            private ListBoxTest lbt;
            private int index;

            //Constructor 
            //publico para ListBoxEnumerator,privado dentro ListBoxTest
            public ListBoxEnumerator(ListBoxTest lista)
            {
                this.lbt = lista;
                //Enumeradores se posicionan antes del primer elemento
                //hasta la primera llamada de MoveNext()
                index = -1;
            }

            //Metodo que  invoca el ciclo foreach para 
            //Incrementa el indice y se asegura de que el valor sea válido
            public bool MoveNext()
            {
                index++;
                return (index < lbt.strings.Length);
            }

            public void Reset()
            {
                index = -1;
            }

            //Propiedad Current=actual, devuelve el valor actual según la posición(index) y la asigna a la variable receptora de foreach 
            //se define como la última cadena agregada a la lista 
            //en este caso al objeto lbt que almacena las cadenas del control listBox
            public object Current
            {
                get 
                {
                    try
                    {
                        return lbt[index];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        
                        throw new InvalidOperationException();
                    }
                    
                }
                
            }

        } // Fin ListBoxEnumerator

        //Método a implementar de la Interface IEnumerable
        //Retorna un enumerador
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) new ListBoxEnumerator(this);
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
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].StartsWith(buscarCadena))
                    return i;
            }
            return -1;
        }

        //Método indexador, sin nombre, por lo tanto usa la palabra reservada <<this>> para identificarlo
        //Da acceso al arreglo mediante un indice
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
         
            //Crea un ListBox y lo inicializa con 2 cadenas
            ListBoxTest lbt = new ListBoxTest("Hola", "Mundo");

            //agrega unas cuantas cadenas
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
            lbt["la"] = "agente!";
            //lbt["abc"] = "e pica"; //probar y hacer cambio para tratar correctamente cuando no se encuentra la cadena

            /*for (int i = 0; i < lbt.GetEntries(); i++)
            {
                Console.WriteLine("lbt[{0}]:{1}", i, lbt[i]);
            }*/

            //Cambio con respecto a los Indexadores
            //Sin la implementación de IEnumerable no se puede usar el ciclo foreach 
            //para recorrer una lista de Objetos del tipo de la clase
            foreach (string s in lbt)
            {
                Console.WriteLine("valor en lbt:{0}",s);
            }

        }// fin main()
    } //fin TEster
}
