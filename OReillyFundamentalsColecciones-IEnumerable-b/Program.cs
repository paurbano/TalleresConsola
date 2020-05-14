using System;
using System.Collections;

namespace OReillyFundamentalsColecciones_IEnumerable_b
{
    public class Persona
    {
        public string Nombre;
        public string apellido;
        public Persona(string n, string a)
        {
            Nombre = n;
            apellido = a;
        }
    }

    //Coleccion de objetos persona. Implementa la interface IEnumerable
    //asi puede usarse con el comando foreach para recorrerla
    public class Gente : IEnumerable 
    {
        private Persona[] personas;
        
        //Constructor
        public Gente(Persona[] lista ) 
        {
            personas = new Persona[lista.Length];
            for (int i = 0; i < lista.Length; i++)
            {
                personas[i] = lista[i];
            }
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return (IEnumerator)GetEnumerator();
        //}


        //también Se debe implementar IEnumerator
        //Enumerador de la interface
        //métodos: MoveNext(),Reset() y Propiedad Current
        public class GenteEnum : IEnumerator
        {
            public Persona[] personas;
            public int posicion = -1;

            public GenteEnum(Persona[] lista)
            {
                personas = lista;
            }

            public bool MoveNext()
            {
                posicion++;
                return (posicion < personas.Length);
            }

            public void Reset()
            {
                posicion = -1;
            }

            //object IEnumerator.Current
            //{
            //    get
            //    {
            //        return this;
            //    }
            //}

            public object Current
            {
                get
                {
                    try
                    {
                        return personas[posicion];
                    }
                    catch (IndexOutOfRangeException)
                    {

                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) new GenteEnum(personas);
        }
    }

   

    class App
    {
        static void Main()
        {
            Persona[] peopleArray = new Persona[4]
        {
            new Persona("Pedro", "Perez"),
            new Persona("Juan", "Pipe"),
            new Persona("Armando", "Casas"),
            new Persona("Armando", "Casas"),
        };

            Gente peopleList = new Gente(peopleArray);
            foreach (Persona p in peopleList)
                Console.WriteLine(p.Nombre + " " + p.apellido);

        }
    }
}
