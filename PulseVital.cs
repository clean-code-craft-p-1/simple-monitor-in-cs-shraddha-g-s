using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class PulseVital : VitalSignBase
    {
        public override string Name => "Pulse Rate";
        public PulseVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }

        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            // If patientDetails or Age is not provided, use adult thresholds by default
            if (patientDetails == null || patientDetails.Age == 0)
                return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);

            if (patientDetails.Age < 2)
                    return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max); // Infant
            
            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max); // Adult
        }
    }
}
