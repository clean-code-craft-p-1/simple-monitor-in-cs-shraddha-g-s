using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class Spo2Vital : IVitalSign
    {
        public string Name => "SpO2";

        public VitalThresholds GetThresholds(PatientDetails patient)
        {
            return new VitalThresholds(95, 100);
        }

        public VitalResult Check(float value, PatientDetails patient = null)
        {
            var thresholds = GetThresholds(patient);
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, "Oxygen saturation too low");
            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, "Oxygen saturation unusually high");
            return new VitalResult(Name, VitalLevel.Normal, "Oxygen saturation normal");
        }
    }
}
