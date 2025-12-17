using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class Spo2Vital : VitalSignBase
    {
        public override string Name => "SpO2";

        public override VitalThresholds GetThresholds(PatientDetails patient)
        {
            return new VitalThresholds(95, 100);
        }
    }
}
