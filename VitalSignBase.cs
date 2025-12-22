
namespace checker
{
    public abstract class VitalSignBase : IVitalSign
    {
        public readonly VitalThresholdConfig ThresholdConfig;

        protected VitalSignBase(VitalThresholdConfig thresholdConfig)
        {
            ThresholdConfig = thresholdConfig ?? throw new ArgumentNullException(nameof(thresholdConfig));
        }

        public abstract string Name { get; }

        // Single source of message formatting to avoid duplication
        public virtual string GetLowMessage() => $"{Name} below normal";
        public virtual string GetHighMessage() => $"{Name} above normal";
        public virtual string GetNormalMessage() => $"{Name} normal";

        // Configure default selection policy in one place (First or Last)
        protected virtual SimpleThresholdConfig SelectDefaultThreshold()
        {
            var d = ThresholdConfig.Thresholds.LastOrDefault(); // switch to FirstOrDefault if needed
            if (d == null)
                throw new InvalidOperationException("No threshold configurations are defined.");
            return d;
        }

        // Centralized selector with range + fallback (no duplication)
        protected virtual SimpleThresholdConfig SelectThresholdForAgeOrDefault(int age)
        {
            var match = ThresholdConfig
                .Thresholds
                .FirstOrDefault(t => age >= t.MinAge && age <= t.MaxAge);

            return match ?? SelectDefaultThreshold();
        }

        public virtual VitalThresholds GetThresholds(PatientDetails patient)
        {
            // Single guard: if patient is null, return default
            if (patient == null)
            {
                var d = SelectDefaultThreshold();
                return new VitalThresholds(d.Min, d.Max);
            }
            var config = SelectThresholdForAgeOrDefault(patient.Age);
            return new VitalThresholds(config.Min, config.Max);
        }

        public VitalResult Check(float value, PatientDetails patient = null)
        {
            var thresholds = GetThresholds(patient);

            // Early returns; minimal branching and no duplicated messages
            if (value < thresholds.Min)
                return new VitalResult(Name, VitalLevel.Low, GetLowMessage());

            if (value > thresholds.Max)
                return new VitalResult(Name, VitalLevel.High, GetHighMessage());

            return new VitalResult(Name, VitalLevel.Normal, GetNormalMessage());
        }
    }
}