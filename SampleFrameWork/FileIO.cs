using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SampleFrameWork
{
    class FileIO
    {

        static void Main(string[] args)
        {
            string DeskTopFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "SampleFile.txt";
            String fileName = "../../FileIO.cs";
            //ReadFile(fileName);
            WriteFile(DeskTopFile);
            
        }
        private static void WriteFile(string DeskTopFile)
        {
            File.WriteAllText(DeskTopFile, "where are you from bro?");
        }
        private static void ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File path is wrong");
            }
            else
            {
                var content = File.ReadAllText(fileName);
                Console.WriteLine(content);
            }
        }
    }
}
