using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace lectorDCM
{
    public class ControlPoint
    {
        public int ControlPointIndex { get; set; }
        public string NominalBeamEnergy { get; set; }
        public int DoseRateSet { get; set; }
        public List<BeamLimitingDevice> BeamLimitingDevices { get; set; }
        public double GantryAngle { get; set; }
        public string GantryRotationDirection { get; set; }
        public double BeamLimitingDeviceAngle { get; set; }
        public double PatientSupportAngle { get; set; }
        public double TableTopVerticalPosition { get; set; }
        public double TableTopLongitudinalPosition { get; set; }
        public double TableTopLateralPosition { get; set; }
        public double SourceToSurfaceDistance { get; set; }
        public double CumulativeMetersetWeight { get; set; }
        

    }
}
