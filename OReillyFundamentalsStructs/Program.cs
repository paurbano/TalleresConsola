using System;

namespace OReillyFundamentalsStructs
{
    /// <summary>
    /// 
    /// Las estructuras no permiten la herencia, se diseñan para ser simples y livianas
    /// No permiten inicializar los campos
    /// Se usan principalmente para manejar datos simples
    /// 
    /// </summary>
    public struct Location
    {
        private int xVal;
        private int yVal;

        //Sino se define un constructor, el compilador crea uno simple por defecto
        //Comente el constructor y descomente la linea en el metodo main
        // ejecute el programa

        //Constructor
        public Location(int x, int y)
        {
            xVal = x;
            yVal = y;
        }

        public int x 
        { 
            get { return xVal; }
            set { xVal = value; }
        }

        public int y
        {
            get { return yVal; }
            set { yVal = value; }
        }

        public override string ToString()
        {
            return (String.Format("{0},{1}",xVal,yVal));
        }
    }

    public class Tester{
        public void myfunc(Location loc){
            loc.x=50;
            loc.y=70;
            Console.WriteLine("En myFunc loc:{0}",loc);
        }

        static void Main()
        {
            Location loc1 = new Location(200, 300);
            
            //Descomentar cuando se comenta constructor
            //Location loc1 = new Location();

            Console.WriteLine("En Main Loc:{0}",loc1);
            Tester t = new Tester();
            t.myfunc(loc1);
            Console.WriteLine("Coordenadas loc:{0}",loc1);
        }
        
    }
}
