using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class DiastolicBloodPressureVital : VitalSignBase
    {
        public override string Name => "Diastolic Blood Pressure";
        public DiastolicBloodPressureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            // If patientDetails or Age is not provided, use adult thresholds by default
            if (patientDetails == null || patientDetails.Age == 0)
                return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);

            if (patientDetails.Age < 13)
                    return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max); // Children
            
            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);        // Adults
        }
    }

}
