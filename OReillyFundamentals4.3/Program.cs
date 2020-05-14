using System;
namespace OReillyFundamentals4._3
{
    /// <summary>
    /// Uso de miembros estáticos
    /// </summary>
    public class Cat
    {

        private static int instances = 0;

        public Cat()
        {
            instances++;
        }

        public static void HowManyCats()
        {
            Console.WriteLine("{0} gatos adoptados", instances);
        }
    }

    public class Tester
    {
        static void Main()
        {
            Cat.HowManyCats();
            Cat frisky = new Cat();
            Cat.HowManyCats();
            Cat whiskers = new Cat();
            Cat.HowManyCats();

        }

    }
}
