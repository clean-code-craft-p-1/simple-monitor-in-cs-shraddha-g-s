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

        public override VitalThresholds GetThresholds(PatientDetails patient)
        {
            if (patient != null)
            {
                if (patient.Age < 1)
                    return new VitalThresholds(80, 160); // Infant
            }
            return new VitalThresholds(60, 100); // Adult
        }
    }
}
