using System;
using System.Collections.Generic;
using System.Text;

namespace lectorDCM
{
    public class Plan
    {
        public Paciente Paciente { get; set; }
        public SOPClassUID SOPClassUID { get; set; }
        public string SOPInstanceUID { get; set; }
        public Modality modality { get; set; }
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
    }

    public enum SOPClassUID
    {
        RTPlanStorage,
        RTBeamsTreatmentRecordStorage,
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
