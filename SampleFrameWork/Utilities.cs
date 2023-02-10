using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class Utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            bool processing = false;
            int result;
            do
            {
                Console.WriteLine(question);
                processing = int.TryParse(Console.ReadLine(), out result);
            } while (!processing);
            return result;
        }

        //public static void LogMessage(string message)
        //{
        //    EventLog eventLog = new EventLog("Starmark", Environment.MachineName, Assembly.GetExecutingAssembly().FullName);
        //    eventLog.WriteEntry(message, EventLogEntryType.Error);
        //}

    }
}