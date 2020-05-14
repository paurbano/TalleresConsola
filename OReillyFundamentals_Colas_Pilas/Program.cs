using System;
using System.Collections;

namespace OReillyFundamentals_Colas_Pilas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cola : Primero en entrar, primero en salir
            Queue colaEnteros = new Queue();
            
            //PIla:ultimo en entrar,primero en salir
            Stack pila = new Stack();

            for (int i = 0; i < 5; i++)
            {
                //Método Enqueue: adiciona un elemento al final de la cola
                colaEnteros.Enqueue(i*3);
                
                //Push, adiciona un elemento al tope de la pila
                pila.Push(i*5);
            }
            Console.WriteLine("Cola:\t");
            ImprimirLista(colaEnteros);

            Console.WriteLine("Pila:\t");
            ImprimirLista(pila);

            //Eliminar un elemento de la cola
            Console.WriteLine("\n Eliminar de la cola(Dequeue)\t{0}", colaEnteros.Dequeue());
            ImprimirLista(colaEnteros);

            //Eliminar de la pila
            Console.WriteLine("\n Eliminar de la pila(Pop)\t{0}", pila.Pop());
            ImprimirLista(pila);

            //Mostrar el primer elemento sin eliminarlo
            Console.WriteLine("Primero de la cola:\t{0}", colaEnteros.Peek());
            ImprimirLista(colaEnteros);

            Console.WriteLine("Primero de la pila:\t{0}", pila.Peek());
            ImprimirLista(pila);



            //Otra forma de crear un arreglo
            //
            Array arreglo = Array.CreateInstance(typeof(int), 10);

            arreglo.SetValue(100,0);
            arreglo.SetValue(200, 1);
            arreglo.SetValue(300, 2);
            arreglo.SetValue(400, 3);
            arreglo.SetValue(500, 4);
            
            Console.WriteLine("Arreglo objetivo");
            ImprimirLista(arreglo);
            
            //Copiar la pila al arreglo desde la posición 5
            pila.CopyTo(arreglo, 5);
            
            Console.WriteLine("Arreglo objetivo despues de copiar pila:\t");
            ImprimirLista(arreglo);
        }

        public static void ImprimirLista(IEnumerable estructura)
        {
            IEnumerator coleccion = estructura.GetEnumerator();
            while(coleccion.MoveNext())
                Console.WriteLine("{0}\t",coleccion.Current);
            Console.WriteLine( );
        }
    }
}
