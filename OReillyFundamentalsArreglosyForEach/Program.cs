using System;

namespace OReillyFundamentalsArreglosyForEach
{
    public class Empleado
    {
        private int empId;

        public Empleado(int Id)
        {
            empId=Id;
        }
        public override string ToString()
        {
            return empId.ToString();
        }
    }

    public class Program
    {
        static void Main()
        {
            
            //Declaración e inicialización de arreglos

                    //Enteros
            //int[] intArreglo;
            //intArreglo = new int[4];
            
            int[] ArregloEnteros = {1,2,3,4,5,6};
            
            int[] intArreglo = new int[4];
                    
                    //Cadenas
            //string[] strArreglo;
            //strArreglo=new string[4];

            string[] strArreglo = new string[3];

            string[] cadenaArreglo = new string[3] { "cadena 1", "cadena 2", "cadena 3" };

            String[] cadArreglo = { "cadena 3", "cadena 2", "cadena 1", "cadena 4" };

            
                    //De Objetos de una Clase
            Empleado[] empArreglo;
            
            empArreglo = new Empleado[2];

            Program p = new Program();
            p.DisplayParams(1, 2, 3, 4);
            p.DisplayParams(ArregloEnteros);
            
            //Llena el arreglo empleados
            for(int i=0;i<empArreglo.Length;i++)
            {
                empArreglo[i]=new Empleado(i+2);
            }

            //imprimir los elementos del arreglo
            //Con ciclo for
            for (int i=0;i<intArreglo.Length;i++)
            {
                Console.WriteLine(intArreglo[i].ToString());
            }

            //con ciclo foreach
            foreach (string s in cadenaArreglo)
            {
                Console.WriteLine(s.ToString());
            }

            //for (int i=0;i<empArreglo.Length;i++)
            //{
            //    Console.WriteLine(empArreglo[i].ToString());
            //}

            //con ciclo foreach
            foreach (Empleado e in empArreglo)
            {
                Console.WriteLine(e.ToString());
            }

            //Metodos útiles del objeto Array
            //Ordenar el arreglo
            Array.Sort(cadArreglo);
            p.DisplayParams(cadArreglo);
            //Invertir el arreglo
            Array.Reverse(cadArreglo);
            p.DisplayParams(cadArreglo);

         }

        /// <summary>
        /// Paso de un arreglo como parametro a un método
        /// Notese el uso de la palabra clave params
        /// De esta forma permite que el arreglo no tenga un tamaño definido al definirlo, solo al instanciarlo
        /// </summary>
        /// <param name="intVal"></param>
        public void DisplayParams(params Object[] intVal)
        {
            Console.WriteLine("Paso de arreglo como parámetro a método \n");
            foreach (Object obj in intVal)
            {
                Console.WriteLine("Valor del arreglo:{0}", obj);
            }
        }
    }
}
