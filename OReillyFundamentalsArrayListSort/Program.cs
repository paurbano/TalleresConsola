using System;
using System.Collections;

namespace OReillyFundamentalsArrayListSort
{
    /// <summary>
    /// Implementar la interface IComparable, para permitir ordenar la clase
    /// por un miembro en particular, en este caso por EmpId o Nombre
    /// </summary>
    public class Empleado:IComparable
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
            return EmpId.ToString() + " - " + Nombre.ToString();
        }

        //Clase Empleado usa el método por defecto para enteros CompareTo 
        public int CompareTo(Object rhs)
        {
            Empleado e = (Empleado)rhs;
            return this.EmpId.CompareTo(e.EmpId);
        }

        //Implementación especial para ser usado por el comparador personalizado para los campos
        public int CompareTo(Empleado rhs,Empleado.EmpleadoComparador.ComparisonType which)
        {
            switch (which)
            {
                case Empleado.EmpleadoComparador.ComparisonType.EmpId:
                    return this.EmpId.CompareTo(rhs.EmpId);
                case Empleado.EmpleadoComparador.ComparisonType.Nombre:
                    return this.Nombre.CompareTo(rhs.Nombre);
                default:
                    return 0;
            }
            
        }

        public static EmpleadoComparador GetComparer()
        {
            return new Empleado.EmpleadoComparador();
        }

        //Clase anidada que implementa IComparer
        public class EmpleadoComparador : IComparer
        {
            //Variable privada para establecer la comparación
            private Empleado.EmpleadoComparador.ComparisonType cualComparar;

            //enumeración de los campos a comparar
            public enum ComparisonType
            {
                EmpId,
                Nombre
            };

            //Dice a los objetos Empleado comparen ellos mismos
            public int Compare(object a,object b)
            {
                Empleado i = (Empleado)a;
                Empleado d = (Empleado)b;
                return i.CompareTo(d, CualComparar);
            }

            public Empleado.EmpleadoComparador.ComparisonType  CualComparar
            {
                get { return cualComparar; }
                set { cualComparar = value; }
            }

        }
    }

    public class prueba
    {
        static void Main()
        {
            ArrayList empleados = new ArrayList();
            empleados.Add(new Empleado(102,"Pedro"));
            empleados.Add(new Empleado(110, "Jose"));
            empleados.Add(new Empleado(1108, "Pablo"));
            empleados.Add(new Empleado(111, "Andres"));
            empleados.Add(new Empleado(1107, "Bart"));

            Empleado.EmpleadoComparador c = Empleado.GetComparer();
            c.CualComparar = Empleado.EmpleadoComparador.ComparisonType.Nombre;
            empleados.Sort(c);

            Console.WriteLine("Ordenados por Nombre");
            foreach(Empleado e in empleados){
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\n");

            c.CualComparar = Empleado.EmpleadoComparador.ComparisonType.EmpId;
            empleados.Sort(c);
            Console.WriteLine("Ordenados por Id");
            foreach (Empleado e in empleados)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
