using System;
using System.Collections.Generic;
using System.Text;

namespace lectorDCM
{
    public class ControlPointDelivery:ControlPoint
    {
        public DateTime TreatmentControlPointDate { get; set; }
        public DateTime TreatmentControlPointTime { get; set; }
        public double SpecifiedMeterset { get; set; }
        public double DeliveredMeterset { get; set; }
        public int DoseRateDelivered { get; set; }
        public int ReferencedControlPointIndex { get; set; }
    }
}
