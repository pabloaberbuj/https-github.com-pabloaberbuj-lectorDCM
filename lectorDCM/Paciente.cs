using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Dicom;

namespace lectorDCM
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public string ID { get; set; }
        public List<Plan> Planes { get; set; }

        public Paciente(DicomFile dcm)
        {
            Nombre = dcm.Dataset.GetSingleValue<string>(DicomTag.PatientName);
            ID = dcm.Dataset.GetSingleValue<string>(DicomTag.PatientID);
            Planes = new List<Plan>();
        }
    }
}
