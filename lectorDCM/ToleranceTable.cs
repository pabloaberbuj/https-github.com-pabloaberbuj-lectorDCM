using System;
using System.Collections.Generic;
using System.Text;

namespace lectorDCM
{
    public class ToleranceTable
    {
        public string ToleranceTableLabel { get; set; }
        public double GantryAngleTolerance { get; set; }
        public double LimitingDeviceAngleTolerance { get; set; }
        public List<BeamLimitingDevice> BeamLimitingDevicesTolerances { get; set; }
    }
}
