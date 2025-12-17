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
        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            if (patientDetails.Age < 12)
                return new VitalThresholds(96, 99);
            return new VitalThresholds(95, 99);
        }
    }
}
