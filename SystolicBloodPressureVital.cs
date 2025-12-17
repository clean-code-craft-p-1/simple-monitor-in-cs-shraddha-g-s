using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class SystolicBloodPressureVital : VitalSignBase
    {
        public override string Name => "Systolic Blood Pressure";

        public override VitalThresholds GetThresholds(PatientDetails patient)
        {
            if (patient != null)
            {
                if (patient.Age < 13)
                    return new VitalThresholds(80, 115); // Children
            }
            return new VitalThresholds(90, 120);        // Adults
        }
    }
}
