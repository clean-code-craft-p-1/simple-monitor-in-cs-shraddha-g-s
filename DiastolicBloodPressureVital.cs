using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class DiastolicBloodPressureVital : IVitalSign
    {
        public string Name => "Diastolic Blood Pressure";

        public VitalThresholds GetThresholds(PatientDetails patient)
        {
            if (patient != null)
            {
                if (patient.Age < 13)
                    return new VitalThresholds(50, 80); // Children
            }
            return new VitalThresholds(60, 80);        // Adults
        }

        public VitalResult Check(float value, PatientDetails patient = null)
        {
            var thresholds = GetThresholds(patient);
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, "Diastolic blood pressure below normal");
            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, "Diastolic blood pressure above normal");
            return new VitalResult(Name, VitalLevel.Normal, "Diastolic blood pressure normal");
        }
    }

}
