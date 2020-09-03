using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace lectorDCM
{
    public class Beam
    {
        public Paciente Paciente { get; set; }
        public Plan Plan { get; set; }
        public Equipo Equipo { get; set; }
        public int BeamNumber { get; set; }
        public string BeamName { get; set; }
        public BeamType BeamType { get; set; }
        public RadiationType RadiationType { get; set; }
        public TreatmentDeliveryType TreatmentDeliveryType { get; set; }
        public int NumberOfWedges { get; set; }
        public string WedgeID { get; set; }
        public List<ControlPoint> ControlPoints { get; set; }
        public string PatientPosition { get; set; }
        public double TableTopVerticalSetupDisplacement { get; set; }
        public double TableTopLongitudinalSetupDisplacement { get; set; }
        public double TableTopLateralSetupDisplacement { get; set; }
        public double BeamDose { get; set; }
        public double BeamMeterset { get; set; }
    }

    public enum BeamType
    {
        Static,
        Dynamic,
    };

    public enum RadiationType
    {
        Photon,
        Electron,
    };
    public enum TreatmentDeliveryType
    {
        Treatment,
        Continuation,
    };

}
