using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class PulseVital : IVitalSign
    {
        public string Name => "Pulse Rate";

        public VitalThresholds GetThresholds(PatientDetails patient)
        {
            if (patient != null)
            {
                if (patient.Age < 1)
                    return new VitalThresholds(80, 160); // Infant
                if (patient.Age < 3)
                    return new VitalThresholds(80, 130); // Toddler
                if (patient.Age < 6)
                    return new VitalThresholds(80, 120); // Preschool
                if (patient.Age < 16)
                    return new VitalThresholds(70, 100); // School-age
            }
            return new VitalThresholds(60, 100); // Adult
        }

        public VitalResult Check(float value, PatientDetails patient = null)
        {
            var thresholds = GetThresholds(patient);
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, "Pulse too low");
            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, "Pulse too high");
            return new VitalResult(Name, VitalLevel.Normal, "Pulse normal");
        }
    }
}
