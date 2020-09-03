using System;
using System.Collections.Generic;
using System.Text;

namespace lectorDCM
{
    public class BeamRecord:Beam
    {
        public DateTime InstanceCreationDate { get; set; }
        public DateTime InstanceCreationTime { get; set; }
        public SOPClassUID SOPClassUID { get; set; }
        public string SOPInstanceUID { get; set; }
        public Modality Modality { get; set; }
        public string OperatorsName { get; set; }
        public int CurrentFractionNumber { get; set; }
        public string TreatmentTerminationStatus { get; set; }
        public string TreatmentVerificationStatus { get; set; }
        public double DeliveredTreatmentTime { get; set; }
        public List<ControlPointDelivery> ControlPointDeliveries { get; set; }
        public DateTime TreatmentDate { get; set; }
        public DateTime TreatmentTime { get; set; }
        public SOPClassUID ReferencedRTPlanSOPClassUID { get; set; }
        public string ReferencedRTPlanSOPInstanceUID { get; set; }
    }
}
