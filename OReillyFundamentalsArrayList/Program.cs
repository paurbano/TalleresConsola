using System;
using System.Collections;

namespace OReillyFundamentalsArrayList
{
    public class Empleado
    {
        public int EmpId { get; set; }
        public string Nombre { get; set; }

        public Empleado(int Id, string nombre)
        {
            EmpId = Id;
            Nombre = nombre;
        }

        public override string ToString()
        {
 	        return EmpId.ToString()+" "+Nombre.ToString();
        }             
    }

    public class Vehiculo 
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        
        public Vehiculo(int Id, string placa)
        {
            IdVehiculo = Id;
            Placa = placa;
        }

        public override string ToString()
        {
            return IdVehiculo.ToString()+"-"+Placa.ToString();
        }

        public int Compare(object x)
        {
            Vehiculo comparaPlaca = (Vehiculo)x;
            return string.Compare(this.Placa,comparaPlaca.Placa);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           ArrayList empleado= new ArrayList();
           ArrayList intArray = new ArrayList();
           ArrayList lista2 = new ArrayList();
           ArrayList carros = new ArrayList();
           
           empleado.Add(new Empleado (100,"Pedro"));
           empleado.Add(new Empleado(102, "Pablo"));
           empleado.Add(new Empleado(101, "Juan"));
           empleado.Add(new Empleado(103, "Pedro"));

           carros.Add(new Vehiculo(10,"plr-468"));
           carros.Add(new Vehiculo(12, "plr-433"));
           carros.Add(new Vehiculo(11, "ayk-123"));
           carros.Add(new Vehiculo(13, "pyn-266"));

           lista2.Add(3); lista2.Add(8); lista2.Add(1); lista2.Add(20); lista2.Add(17);
            
           // carros.Sort();
           
           Random r = new Random();
            
           for (int i = 0; i < empleado.Capacity; i++)
           {
               intArray.Add(r.Next(5));
           }

           lista2.AddRange(intArray);
           //lista2.AddRange(empleado);

           Console.WriteLine("Agrego otras listas a lista2, listar los enteros");
           foreach (int i in lista2)
           {
               Console.WriteLine(i);
           }

           lista2.RemoveAt(3);
           lista2.Insert(5, 9);
           
            Console.WriteLine("Después de remover posición (4) e insertar un objeto (2) en (9) diferentes posiciones");
           foreach (int i in lista2)
           {
               Console.WriteLine(i);
           }

            for (int i = 0; i < empleado.Capacity; i++)
            {
                Console.WriteLine("Empleado:{0}",empleado[i].ToString());
                Console.WriteLine("ArrayList enteros:{0}",intArray[i].ToString());
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Capacidad:{0}",empleado.Capacity);
            
            //empleado.Sort();

            intArray.Sort();
            Console.WriteLine("Enteros Ordenados con el método por defecto Sort()");
            for (int i = 0; i < intArray.Capacity; i++)
            {
                Console.WriteLine(intArray[i].ToString());
            }

            //Console.WriteLine("Empleado ordenado");
            //for (int i = 0; i < empleado.Capacity; i++)
            //{
            //    Console.WriteLine("Empleado:{0}", empleado[i].ToString());
            //}
        }
    }
}
