using System;
using System.Collections.Generic;
using System.Text;
using Dicom;

namespace lectorDCM
{
    public class Plan
    {
        public Paciente Paciente { get; set; }
        public SOPClassUID SOPClassUID { get; set; }
        public string SOPInstanceUID { get; set; }
        public Modality Modality { get; set; }
        public string StudyDescription { get; set; }
        public string OperatorName { get; set; }
        public string PlanLabel { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime PlanTime { get; set; }
        public double TargetPrescriptionDose { get; set; }
        public int NumberOfFractionsPlanned { get; set; }
        public List<Beam> Beams { get; set; }
        public ToleranceTable ToleranceTable { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime ReviewTime { get; set; }
        public string ReviewerName { get; set; }

        public void Extraer(string archivo)
        {
            var dcm = DicomFile.Open(archivo);
            Paciente = new Paciente(dcm);
            Paciente.Planes.Add(this);
            StudyDescription = dcm.Dataset.GetSingleValue<string>(DicomTag.StudyDescription);
            //OperatorName = dcm.Dataset.TryGetValue<string>(DicomTag.OperatorsName);
            PlanLabel = dcm.Dataset.GetSingleValue<string>(DicomTag.RTPlanLabel);
            PlanDate = dcm.Dataset.GetSingleValue<DateTime>(DicomTag.RTPlanDate);
            PlanTime = dcm.Dataset.GetSingleValue<DateTime>(DicomTag.RTPlanTime);
            SOPClassUID = ObtenerSOPClassUID(dcm);
            SOPInstanceUID = dcm.Dataset.GetSingleValue<string>(DicomTag.SOPInstanceUID);
            Modality = (Modality)Enum.Parse(typeof(Modality), dcm.Dataset.GetSingleValue<string>(DicomTag.Modality));
            var DoseReferenceSequence = dcm.Dataset.GetSequence(DicomTag.DoseReferenceSequence);
            var FractionGroupSequence = dcm.Dataset.GetSequence(DicomTag.FractionGroupSequence);
            var ReferencedBeamSequence = FractionGroupSequence.Items[0].GetSequence(DicomTag.ReferencedBeamSequence);
            TargetPrescriptionDose = DoseReferenceSequence.Items[0].GetSingleValue<double>(DicomTag.TargetPrescriptionDose);
            NumberOfFractionsPlanned = FractionGroupSequence.Items[0].GetSingleValue<int>(DicomTag.NumberOfFractionsPlanned);
            Beams = new List<Beam>();
            var beamSequence = dcm.Dataset.GetSequence(DicomTag.BeamSequence);
            foreach (var beamDcm in beamSequence)
            {
                DicomDataset referencedBeam = new DicomDataset();
                foreach (var refBeam in ReferencedBeamSequence)
                {
                    if (refBeam.GetSingleValue<int>(DicomTag.ReferencedBeamNumber) == beamDcm.GetSingleValue<int>(DicomTag.BeamNumber))
                    {
                        referencedBeam = refBeam;
                        break;
                    }
                }
                Beam campo = new Beam();
                campo.Extraer(beamDcm,referencedBeam);
                Beams.Add(campo);
            }
            ApprovalStatus = (ApprovalStatus)Enum.Parse(typeof(ApprovalStatus), dcm.Dataset.GetSingleValue<string>(DicomTag.ApprovalStatus),true);
        }

        public static SOPClassUID ObtenerSOPClassUID(DicomFile dcm)
        {
            if (dcm.Dataset.GetSingleValue<string>(DicomTag.SOPClassUID) == "1.2.840.10008.5.1.4.1.1.481.4")
            {
                return SOPClassUID.RTBeamsTreatmentRecordStorage;
            }
            else if (dcm.Dataset.GetSingleValue<string>(DicomTag.SOPClassUID) == "1.2.840.10008.5.1.4.1.1.481.5")
            {
                return SOPClassUID.RTPlanStorage;
            }
            else
            {
                return SOPClassUID.Unknow;
            }
        }

    }

    public enum SOPClassUID
    {
        RTPlanStorage,
        RTBeamsTreatmentRecordStorage,
        Unknow,
    };

    public enum Modality
    {
        RTPLAN,
        RTRECORD,
    };

    public enum ApprovalStatus
    {
        Approved,
        Unapproved,
        Rejected,
    };

}
