using Entities;
using SampleConsoleApp;
using SampleConsoleApp.FirstAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILayer;



namespace Entities
{
    class Disease
    {
        public string DiseaseId
        { get; set; }
        public string DiseaseName { get; set; }
        public string Severity { get; set; }
        public string Factors { get; set; }
        public int Id { get; internal set; }

        public static implicit operator Disease(Symptom v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Disease(Patient v)
        {
            throw new NotImplementedException();
        }
    }
    class Symptom
    {
        public string SymptomName
        { get; set; }
        public string DiseaseName { get; set; }
        public string SymtomName { get; internal set; }
    }
    class Patient
    {
        public string PatientName { get; set; }
        public string SymtomName { get; set; }

    }
}

namespace SampleConsoleApp.FirstAssessment
{
    class DiseaseRepository
    {
        private Disease[] _diseases = null;

        private readonly int _size = 0;
        public DiseaseRepository(int size)
        {
            _size = size;
            _diseases = new Disease[_size];

        }






        public int AddDisease(Disease disease)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_diseases[i] == null)
                {
                    _diseases[i]
                        = new Disease { Id = disease.Id, DiseaseName = disease.DiseaseName, Severity = disease.Severity, Factors = disease.Factors };




                    return 1;//To exit
                }
            }
            return _size;
        }

        internal int AddSymptom(Symptom symptom)
        {
            throw new NotImplementedException();
        }

        internal int AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }




    class SymptomsRepository
    {

        private Symptom[] symptoms = null;


        private readonly int _size = 0;
        private readonly Symptom[] _symptoms;

        public SymptomsRepository(int size)
        {
            _size = size;
            //  _symptoms = new Symptom[size];


        }
        public int AddSymptom(Symptom symptom)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_symptoms[i] == null)
                {
                    _symptoms[i]
                        = new Symptom
                        {
                            DiseaseName = symptom.DiseaseName,
                            SymptomName = symptom.SymptomName
                        };

                    return 1;//To exit
                }
            }
            return _size;
        }
    }





        class PatientRepository
        {

            private Patient[] patients = null;


            private readonly int _size = 0;
            private readonly Patient[] _patients;


            public PatientRepository(int size)
            {
                _size = size;
                //  _symptoms = new Symptom[size];


            }

            public int AddPatient(Patient patient)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_patients[i] == null)
                    {
                        _patients[i]
                               = new Patient
                               {
                                   PatientName = patient.PatientName,
                                   SymtomName = patient.SymtomName
                               };

                        return 1;//To exit
                    }
                }
                return _size;
            }


        }


        class UIManager
        {

            public static DiseaseRepository repo = null;
            enum Options
            {
                Disease = 1, Symptom = 2,
                Check = 3
            }

            public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~=MEDICAL RESEARCH APPLICATION~~~~~~~~~~~~~~~~~~~\n" +
                "TO ADD DISEASE------------------------>PRESS 1\nTO ADD SYMPTOM--------->PRESS 2\nTO CHECK THE PATIENT----------------->PRESS 3\n------------------------->\n" +
                "PS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";




            public static void Run()
            {
                int size = Utilities.GetNumber("Enter the number of patient details you want to enter");
                repo = new DiseaseRepository(size);
                bool processing = true;
                do
                {
                    Options option = (Options)Utilities.GetNumber(menu);
                    processing = processMenu(option);
                } while (processing);
                Console.WriteLine("Thanks for Using our Application!!!");
            }

            private static bool processMenu(Options option)
            {
                switch (option)
                {
                    case Options.Disease:
                        AddingDisease();
                        break;
                    case Options.Symptom:
                        AddingSymptom();
                        break;
                    case Options.Check:
                        AddingPatient();
                        break;

                    default:
                        return false;
                }
                return true;
            }

            //enum ExtenalOrInternal
            //{
            //    externalfactor
            //        = 1, internalfactor = 2
            //}
            private static void AddingDisease()
            {

                int id = Utilities.GetNumber("Enter the id");
                string diseasename =
                    Utilities.Prompt("Enter the name of the disease");
                string severity
                    = Utilities.Prompt("Enter the severity of the disease('high' , 'medium' ,'low')");

                string factors
                    = Utilities.Prompt("Enter 1 if caused by external factor or 2 if caused by internal factor");
                //string description =
                //    Utilities.Prompt("Enter more about your condition");


                Disease disease = new Disease
                { Id = id, DiseaseName = diseasename, Severity = severity, Factors = factors };

                int result = repo.AddDisease(disease);
                if
             (result == 1)
                {
                    Console.WriteLine("disease details added successfully");
                }

                SampleConsoleApp.Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            }

            private static void AddingSymptom()
            {
                string diseasename =
                  Utilities.Prompt("Enter the name of the disease");
                string symptomname
                    = Utilities.Prompt("Enter the symptom of the disease");

                Symptom symptom = new Symptom
                {
                    SymtomName = symptomname,
                    DiseaseName = diseasename
                };
                int res = repo.AddSymptom(symptom);

                if
             (res == 1)
                {
                    Console.WriteLine("symtoms  added successfully");
                }

                SampleConsoleApp.Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            }
            private static void AddingPatient()
            {
                string patientname =
                  Utilities.Prompt("Enter the name of the patient");
                string symptomname
                    = Utilities.Prompt("Enter the symptom of the disease");

                Patient patient = new Patient
                {
                    patientname = patientname,
                    SymtomName = symptomname,

                };
                int re = repo.AddPatient(patient);

                if
             (re == 1)
                {
                    Console.WriteLine("patient details added successfully");
                }

                SampleConsoleApp.Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            }


        }


        class MedicalResearchApp
        {



            static void Main(string[] args)
            {
                UIManager.Run();
            }
        }
    }


    
