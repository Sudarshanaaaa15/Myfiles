using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;


namespace SampleFrameWork.Practical
{
    [Serializable]
    public class EmpSoap
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public override string ToString()
        {
            return ($"{EmpName} from {EmpAddress}");
        }
    }
    class SoapSerealisation
    {
        static void Main(string[] args)
        {
            SoapSerealize();
            SoapDeSerealize();
        }

        private static void SoapDeSerealize()
        {
            EmpSoap employee = null;
            FileStream Fs = new FileStream("Emp.xml", FileMode.Open, FileAccess.Read);
            SoapFormatter format = new SoapFormatter();
            employee = format.Deserialize(Fs) as EmpSoap;
            Fs.Close();
            Console.WriteLine(employee);
        }

        private static void SoapSerealize()
        {
            EmpSoap empSoap = new EmpSoap
            {
                EmpId=111,
                EmpName="suresh",
                EmpAddress="Raipur"
            };
            FileStream Fs = new FileStream("Emp.xml", FileMode.OpenOrCreate, FileAccess.Write);
            SoapFormatter format = new SoapFormatter();
            format.Serialize(Fs, empSoap);
            Fs.Close();

        }
    }
}
