using System;
using System.Linq;
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

        public void asignarPaciente(List<Paciente> pacientes, Plan plan)
        {
            if (pacientes.Count>0 && pacientes.Any(p=>p.Nombre==Nombre && p.ID == ID))
            {
                pacientes.Where(p => p.Nombre == Nombre && p.ID == ID).First().Planes.Add(plan);
            }
            else
            {
                Planes.Add(plan);
                pacientes.Add(this);
            }
        }

        public override string ToString()
        {
            return ID + "-" + Nombre;
        }
    }
}
