using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
    class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PhoneNo { get; set; }
        public int Bill { get; set; }
        public override string ToString()
        {
            return ($"{PatientId},{PatientName},{Bill},{PhoneNo}\n");
        }
    }
    class PatientCSV
    {
        const string PathName = "../../Patientdata.csv";
        static void Main(string[] args)
        {
            var choice = Utilities.Prompt("Add or View. Press A for adding or V for Viewing");
            if (choice.ToUpper() == "A")
                WritingFile();
            else if (choice.ToUpper() == "V")
                ReadingFile();
            else
                Console.WriteLine("Wrong Choice");
        }
        private static void ReadingFile()
        {
            List<Patient> patients = new List<Patient>();
            var allPatientData = File.ReadAllLines(PathName);

            foreach (var datas in allPatientData)
            {
                var words = datas.Split(',');
                Patient data = new Patient();
                data.PatientId = int.Parse(words[0]);
                data.PatientName = words[1];
                data.PhoneNo = int.Parse(words[2]);
                data.Bill = int.Parse(words[3]);
                patients.Add(data);
               // Console.WriteLine(data);
                
            }

            foreach (var data in patients)
            {
                Console.WriteLine(data.PatientId);
                Console.WriteLine(data.PatientName);
            }
        }
        private static void WritingFile()
        {
            Patient pat = new Patient
            {
                PatientId = Utilities.GetNumber("Enter the Patient ID"),
                PatientName = Utilities.Prompt("Enter the Patient name"),
                PhoneNo = Utilities.GetNumber("Enter the Patient Phone"),
                Bill = Utilities.GetNumber("Enter the Bill Amount")
            };
            File.AppendAllText(PathName, pat.ToString());
        }


    }

}

