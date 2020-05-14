using System;
namespace OReillyFundamentalsArreglosMatrices
{
    class Program
    {
        /// <summary>
        /// Definición de clase genérica Matriz
        /// el parametro T entre <> hace que la clase pueda ser instanciada de acuerdo al tipo de dato que se le defina
        /// p.e : Matriz<String> matriz=new Matriz("3","4")
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Matriz<T>
        {
            public int filas { get; set; }
            public int columnas { get; set; }

            private T[,] matriz;
            public Matriz(int f, int c)
            {
                this.filas = f;
                this.columnas = c;
                matriz=new T[filas,columnas];
            }

            public void Tamaño()
            {
                
                Console.WriteLine("Matriz de:{0}x{1}", filas, columnas);
            }
            public void Transpuesta()
            {
                Console.WriteLine("Devuelve la matriz transpuesta:{0}x{1}",columnas,filas);
                //Por hacer: algoritmo de transpuesta de una matriz
            }
            public void Inversa()
            {
                Console.WriteLine("Devuelve la matriz Inversa");
                //Por hacer: algoritmo que invierte una matriz
            }

            public bool esCuadrada()
            {
                if (filas.Equals(columnas))
                {
                    Console.WriteLine("Es Cuadrada..");
                    return true;
                }
                else
                {
                    Console.WriteLine("No es Cuadrada..");
                    return false;
                }
            }
        }
        static void Main(string[] args)
        {
            int filas,columnas;
            int[,] matriz;
            string[,] matriz2=new string[2,2];

            matriz2[0, 1] = "Hola";
            matriz2[1, 1] = "Hola mundo";

            Console.WriteLine("Ingresa el número de filas:");
            filas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el número de Columnas:");
            columnas =int.Parse(Console.ReadLine());
            
            matriz=new int[filas,columnas];
            
            //Objeto matriz
            Matriz<int> matrix = new Matriz<int>(filas, columnas);

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.WriteLine("Ingresa el dato para la celda:{0},{1} \t",i,j);
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
                
            }

            matrix.Tamaño();
            matrix.esCuadrada();
            matrix.Transpuesta();
            matrix.Inversa();
            
        }    
    }
}
