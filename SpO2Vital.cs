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
            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);
        }
    }
}
