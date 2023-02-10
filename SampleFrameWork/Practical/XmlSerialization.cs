using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleFrameWork.Practical
{
    public class Employeee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public override string ToString()
        {
            return ($"{EmpName} from {EmpAddress}");
        }
    }
    class XmlSerialization
    {
        static void Main(string[] args)
        {
            xmlSerialize();
            xmlDeserialize();
        }

        private static void xmlDeserialize()
        {
            Employeee emp = null;
            FileStream Fs = new FileStream("Emp.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer fm = new XmlSerializer(typeof(Employeee));
            emp = fm.Deserialize(Fs) as Employeee;
            Fs.Close();
            Console.WriteLine(emp);
        }
        private static void xmlSerialize()
        {
            Employeee emp = new Employeee
            {
                EmpId = 112,
                EmpAddress = "Bangalore",
                EmpName = "Rajesh"
            };

            FileStream fs = new FileStream("Emp.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer format = new XmlSerializer(typeof(Employeee));
            format.Serialize(fs, emp);
            fs.Close();
        }

    }
}
