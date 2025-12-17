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

        public override VitalThresholds GetThresholds(PatientDetails patient)
        {
            if (patient != null)
            {
                if (patient.Age < 13)
                    return new VitalThresholds(50, 80); // Children
            }
            return new VitalThresholds(60, 80);        // Adults
        }
    }

}
