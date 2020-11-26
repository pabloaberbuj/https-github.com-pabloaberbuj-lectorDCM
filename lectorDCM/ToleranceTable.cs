using System;
using System.Collections.Generic;
using System.Text;
using Dicom;

namespace lectorDCM
{
    public class ToleranceTable
    {
        public string ToleranceTableLabel { get; set; }
        public double GantryAngleTolerance { get; set; }
        public double LimitingDeviceAngleTolerance { get; set; }
        public List<BeamLimitingDevice> BeamLimitingDevicesTolerances { get; set; } //Todavía no lo hice, ver si vale la pena

        public double PatientSupportAngleTolerance { get; set; }
        public double TableTopVerticalPositionTolerance { get; set; }
        public double TableTopLongitudinalPositionTolerance { get; set; }
        public double TableTopLateralPositionTolerance { get; set; }

        public ToleranceTable(DicomFile dcm)
        {
            var ToleranceTableSequence = dcm.Dataset.GetSequence(DicomTag.ToleranceTableSequence);
            ToleranceTableLabel = ToleranceTableSequence.Items[0].GetSingleValue<string>(DicomTag.ToleranceTableLabel);
            GantryAngleTolerance = ToleranceTableSequence.Items[0].GetSingleValue<double>(DicomTag.GantryAngleTolerance);
            LimitingDeviceAngleTolerance = ToleranceTableSequence.Items[0].GetSingleValue<double>(DicomTag.BeamLimitingDeviceAngleTolerance);
            PatientSupportAngleTolerance = ToleranceTableSequence.Items[0].GetSingleValue<double>(DicomTag.PatientSupportAngleTolerance);
            TableTopVerticalPositionTolerance = ToleranceTableSequence.Items[0].GetSingleValue<double>(DicomTag.TableTopVerticalPositionTolerance);
            TableTopLongitudinalPositionTolerance = ToleranceTableSequence.Items[0].GetSingleValue<double>(DicomTag.TableTopLongitudinalPositionTolerance);
            TableTopLateralPositionTolerance = ToleranceTableSequence.Items[0].GetSingleValue<double>(DicomTag.TableTopLateralPositionTolerance);
        }
    }
}
