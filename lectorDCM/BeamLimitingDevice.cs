using System;
using System.Collections.Generic;
using System.Text;

namespace lectorDCM
{
    public class BeamLimitingDevice
    {
        public string BeamLimitingDeviceType { get; set; }
        public double[] Position { get; set; }
        public double Tolerance { get; set; }
    }
    
}
