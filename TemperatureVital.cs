using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace checker
{
    public class TemperatureVital : VitalSignBase
    {
        public override string Name => "Temperature";
        public TemperatureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }

        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            // If patientDetails or Age is not provided, use adult thresholds by default
            if (patientDetails == null || patientDetails.Age == 0)
                return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);

            if (patientDetails.Age < 12)
                return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max);
            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);
        }
    }
}
