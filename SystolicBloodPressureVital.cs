using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class SystolicBloodPressureVital : IVitalSign
    {
        public string Name => "Systolic Blood Pressure";

        public VitalThresholds GetThresholds(PatientDetails patient)
        {
            if (patient != null)
            {
                if (patient.Age < 13)
                    return new VitalThresholds(80, 115); // Children
            }
            return new VitalThresholds(90, 120);        // Adults
        }

        public VitalResult Check(float value, PatientDetails patient = null)
        {
            var thresholds = GetThresholds(patient);
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, "Systolic blood pressure below normal");
            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, "Systolic blood pressure above normal");
            return new VitalResult(Name, VitalLevel.Normal, "Systolic blood pressure normal");
        }
    }
}
