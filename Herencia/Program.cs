using System;

namespace Herencia
{
    class Program
    {
        public class ClaseA {
            public ClaseA()
            {
                Console.WriteLine("Constructor Clase A");
            }
        }

        public class ClaseB : ClaseA
        {
            public ClaseB()
            {
                Console.WriteLine("Constructor Clase B");
            }
        }

        public class ClaseC : ClaseB
        {
            public ClaseC()
            {
                Console.WriteLine("Constructor Clase C");
            }
        }
        static void Main(string[] args)
        {
            ClaseC c = new ClaseC();
            
        }
    }
}
