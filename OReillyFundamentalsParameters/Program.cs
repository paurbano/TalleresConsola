using System;

namespace OReillyFundamentalsParameters
{
    public class Time
    {
        //miembros privados de la clase variables
        private int Year;
        private int Month;
        private int Date;
        private int Hour;
        private int Minute;
        private int Second;

        // constructor
        public Time(System.DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Date = dt.Day;
            Hour = dt.Hour;
            Minute = dt.Minute;
            Second = dt.Second;
        }

        //Métodos publicos
        public void DisplayCurrentTime()
        {
            System.Console.WriteLine("{0}/{1}/{2} {3}:{4}:{5}",  Month, Date, Year, Hour, Minute, Second);
        }

        private int GetHour()
        {
            return Hour;
        }
        
        //Definición método con los parámetos y su tipo: valor o referencia -ref-
        public void GetTime(ref int h,ref int m,ref int s)
        {
            h = Hour+1;
            m = Minute;
            s = Second;
        }

        public void SetTime(int hr, out int min,ref int sec)
        {
            if (sec >= 30)
            {
                Minute++;
                Second = 0;
            }
            Hour = hr;
            min = Minute;
            sec=Second;
        }
    }

    public class Tester
    {
        static void Main()
        {
            System.DateTime currentTime = System.DateTime.Now;
            Time t = new Time(currentTime);
            t.DisplayCurrentTime();

            int theHour =1;
            int theMinute;
            int theSecond = 25;
            
            //paso de parámteros al método según la definición
            t.SetTime(theHour, out theMinute, ref theSecond);
            Console.WriteLine("Tiempo UTC: {0}:{1}:{2}",theHour,theMinute,theSecond);

            //paso de parámetros al método, según la definición
            t.GetTime(ref theHour,ref theMinute,ref theSecond);
            System.Console.WriteLine("Hora actual: {0}:{1}:{2}", theHour, theMinute, theSecond);

        }

    }

}
