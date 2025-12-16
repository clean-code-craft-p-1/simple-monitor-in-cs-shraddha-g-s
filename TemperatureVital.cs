using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class TemperatureVital : IVitalSign
    {
        public string Name => "Temperature";
        public VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            if (patientDetails.Age < 12)
                return new VitalThresholds(96, 99);
            return new VitalThresholds(95, 99);
        }

        public VitalResult Check(float value, PatientDetails patientDetails = null)
        {
            var thresholds = GetThresholds(patientDetails);
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, "Temperature too low");
            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, "Temperature too high");
            return new VitalResult(Name, VitalLevel.Normal);
        }
    }
}
