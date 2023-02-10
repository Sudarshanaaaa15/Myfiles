using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    delegate void Wake(string mesg);
    class Clock
    {
        private static DateTime _TimeSet;
        public static event Wake On_Timeset;
        //public static void setAlaram(Datetime time)
        //{
        //    _Timeset = time;
        //}

        internal static void DisplayClock()
        {
            do
            {
                if (DateTime.Now.Minute == _TimeSet.Minute)
                {
                    if (On_Timeset != null)
                    {
                        On_Timeset("IM GOING");
                        //Console.Beep(3500, 10000);
                    }
                }
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(1000);
                Console.Clear();
            } while (true);
        }
    }
    class EventHandler
    {
        static void Main(string[] args)
        {
            Clock.On_Timeset += new Wake(Clock_OnTimeSet);
            //Clock.SetAlaram(DateTime.Now.AddSeconds(30));
            Clock.DisplayClock();
        }

        private static void Clock_OnTimeSet(string mesg)
        {
            Console.WriteLine(mesg);
        }
    }
}
