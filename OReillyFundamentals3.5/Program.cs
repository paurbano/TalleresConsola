using System;

namespace OReillyFundamentals3._5
{
    public class Time
    {

        // variables miembro privadas
        int Year;
        int Month;
        int Date;
        int Hour;
        int Minute;
        int Second;
        
        private static string Name;

        // método de acceso público
        public void DisplayCurrentTime()
        {
            System.Console.WriteLine("Nombre:{0}",Name);
            System.Console.WriteLine("{0}/{1}/{2} {3}:{4}:{5}", Month, Date, Year, Hour, Minute, Second);
        }

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

        public Time(Time existingTimeObject)
        {
            Year = existingTimeObject.Year;
            Month = existingTimeObject.Month;
            Date = existingTimeObject.Date;
            Hour = existingTimeObject.Hour;
            Minute = existingTimeObject.Minute;
            Second = existingTimeObject.Second;
        }

        static Time()
        {
            Name = "Horario";
        }


    }
    
    public class Tester
    {
        static void Main()
        {
            System.DateTime currentTime = System.DateTime.Now;
            Time t = new Time(currentTime);
            Time t1 = new Time(t);
            t.DisplayCurrentTime();

        }
    }
        
}
