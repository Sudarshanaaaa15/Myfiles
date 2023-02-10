using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
    [Serializable]
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public override string ToString()
        {
            return $"{EmpName} from {EmpAddress}";
        }

    }
    class BinarySerialisation
    {
        static void Main(string[] args)
        {
            Serialise();
            Deserealise();
        }

        private static void Deserealise()
        {
            Employee employee = null;
            FileStream Fs = new FileStream("Emp.Bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter format = new BinaryFormatter();
            employee = format.Deserialize(Fs) as Employee;
            Fs.Close();
            Console.WriteLine(employee);
        }

        private static void Serialise()
        {
            Employee employee = new Employee
            {
                EmpId = 111,
                EmpName = "ramesh",
                EmpAddress = "manvi"
            };
            FileStream fs = new FileStream("Emp.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, employee);
            fs.Close();
        }
    }
}
