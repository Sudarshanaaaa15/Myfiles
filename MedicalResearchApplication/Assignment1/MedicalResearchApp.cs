using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFramework
{
   
    class Disease
    {
        public string DiseaseName { get; set; }
        public string Severity { get; set; }
    }

    class Symptom
    {
        public string DiseaseName { get; set; }
        public string Symptoms { get; set; }
        public string Discription { get; set; }
    }
    class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Disease { get; set; }
        public string Symptoms { get; set; }
    }
    class MedResearchManager
    {
        private Disease[] dis = null;
        private Symptom[] sym = null;
        int _size = 0;

        public MedResearchManager   (int size)
        {
            _size = size;
            sym = new Symptom[_size];
            dis = new Disease[_size];
        }

        public void AddDisease(Disease disease)
        {
            for (int i = 0; i < dis.Length; i++)
            {
                if (dis[i] == null)
                {
                    dis[i] = new Disease { DiseaseName = disease.DiseaseName, Severity = disease.Severity };
                    return;
                }
            }
            throw new Exception("This type of Disease not Exist");
        }
        public void AddSymptom(Symptom symptom)
        {
            for (int i = 0; i < dis.Length; i++)
            {
                sym[i] = new Symptom { DiseaseName = symptom.DiseaseName, Symptoms = symptom.Symptoms, Discription = symptom.Discription };
                return;

            }
        }
        public void Patient()
        {
            Console.WriteLine("Enter the Patient Name");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter the Symptoms");
            string SymptomType = Console.ReadLine();
            if (dis != null)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    try
                    {
                        if (sym[i].Symptoms.Contains(SymptomType))
                        {
                            Console.WriteLine("Disease is: " + sym[i].DiseaseName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }

    class MedicalResearchApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of diseases");
            int size = Convert.ToInt32(Console.ReadLine());
            MedResearchManager medical = new MedResearchManager(size);
            void addDiseaseDetails()
            {
                Console.WriteLine("Enter a Disease Name");
                string disease = Console.ReadLine();

                Console.WriteLine("Enter a Severity as [Low or Medium or High]");
                string severity = Console.ReadLine();

                Disease disease1 = new Disease { DiseaseName = disease, Severity = severity };
                medical.AddDisease(disease1);
            }

            void addSymptomDetails()
            {
                Console.WriteLine("Enter the Disease Name");
                string disease = Console.ReadLine();
                Console.WriteLine("Enter the Symptoms");
                string symptom = Console.ReadLine();
                Console.WriteLine("Enter the Cause {Internal or External}");
                string cause = Console.ReadLine();
                Console.WriteLine("Enter the Description with Minimum of 30 Characters");
                string description = Console.ReadLine();

                Symptom symptom1 = new Symptom { DiseaseName = disease, Symptoms = symptom, Discription = description };
                medical.AddSymptom(symptom1);
            }
            bool operation = true;
            do
            {
                Console.WriteLine("--------------MEDICAL RESEARCH APPLICATION----------");
                Console.WriteLine("TO ADD DISEASE DATAILS ----->PRESS 1\n TO ADD SYMPTOMS DETAILS ------>PRESS 2\n TO CHECK PATIENT DETAILS ---------> PRESS 3");
                string choices = Console.ReadLine();
                switch (choices)
                {
                    case "1":
                        addDiseaseDetails();
                        break;
                    case "2":
                        addSymptomDetails();
                        break;
                    case "3":
                        checkPatientDetails();
                        break;
                }
            }
            while (operation);
            void checkPatientDetails()
            {
                medical.Patient();
            }
        }
    }
}