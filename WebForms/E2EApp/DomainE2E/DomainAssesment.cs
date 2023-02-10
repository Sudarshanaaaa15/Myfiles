using DomainE2E.DataLayer;
using DomainE2E.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainE2E
{
    namespace Entities
    {
        class Patient
        {
            public int PatientId { get; set; }
            public string PatientName { get; set; }
            public string PatientAddress { get; set; }
            public string PatientDisease { get; set; }
        }
        class Doctor
        {
            public int DoctorId { get; set; }
            public string DoctorSpecialization { get; set; }
        }
    }
    namespace DataLayer
    {
        interface IPatientDataAccess
        {
            void AddNewPatient(Patient patient);
            void UpdatePatient(Patient patient);
            void DeletePatient(int id);
            List<Patient> GetAllPatients();
            List<Doctor> GetAllDoctors();
        }
        class DataAccess : IPatientDataAccess
        {
            private string STRCONNECTION = string.Empty;


            const string STRINSERT = "InsertPatient";

            public void AddNewPatient(Patient patient)
            {
                throw new NotImplementedException();
            }

            public void UpdatePatient(Patient patient)
            {
                throw new NotImplementedException();
            }

            public void DeletePatient(int id)
            {
                throw new NotImplementedException();
            }

            public List<Patient> GetAllPatients()
            {
                throw new NotImplementedException();
            }

            public List<Doctor> GetAllDoctors()
            {
                throw new NotImplementedException();
            }
        }
    }
    
    namespace UIMain
    {

        using DomainE2E.DataLayer;
        using System.Configuration;
        class DomainAssesment
        {

            static IPatientDataAccess component = null;
            static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            static void Main(string[] args)
            {

            }
        }

    }
}
