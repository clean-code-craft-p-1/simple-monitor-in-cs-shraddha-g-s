using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class SpO2Vital : VitalSignBase
    {
        public override string Name => "SpO2";
        public SpO2Vital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            // If patientDetails or Age is not provided, use adult thresholds by default
            if (patientDetails == null || patientDetails.Age == 0)
                return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);
            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);
        }
    }
}
