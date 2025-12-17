using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public abstract class VitalSignBase : IVitalSign
    {
        public abstract string Name { get; }
        public abstract VitalThresholds GetThresholds(PatientDetails patient);

        public virtual string GetLowMessage() => $"{Name} below normal";
        public virtual string GetHighMessage() => $"{Name} above normal";
        public virtual string GetNormalMessage() => $"{Name} normal";

        public VitalResult Check(float value, PatientDetails patient = null)
        {
            var thresholds = GetThresholds(patient);
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, GetLowMessage());
            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, GetHighMessage());
            return new VitalResult(Name, VitalLevel.Normal, GetNormalMessage());
        }
    }

}
