namespace checker
{
    public abstract class VitalSignBase : IVitalSign
    {
        public readonly VitalThresholdConfig ThresholdConfig;

        public VitalSignBase(VitalThresholdConfig thresholdConfig)
        {
            ThresholdConfig = thresholdConfig;
        }

        public abstract string Name { get; }

        public virtual string GetLowMessage() => $"{Name} below normal";
        public virtual string GetHighMessage() => $"{Name} above normal";
        public virtual string GetNormalMessage() => $"{Name} normal";

        public virtual VitalThresholds GetThresholds(PatientDetails patient)
        {
            int? age = patient?.Age;
            SimpleThresholdConfig config;

            if (age.HasValue && age.Value > 0)
            {
                config = ThresholdConfig.Thresholds.FirstOrDefault(t => age.Value >= t.MinAge && age.Value <= t.MaxAge);
            }
            else
            {
                // Age not specified: use the first threshold as default
                config = ThresholdConfig.Thresholds.Last();
            }
            return new VitalThresholds(config.Min, config.Max);
        }
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
