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
            // Decision 1
            if (patient == null)
            {
                var d = GetDefaultThreshold();       // First or Last per your policy
                return new VitalThresholds(d.Min, d.Max);
            }

            // Decision 2 (if Age is non-nullable int and you treat 0 as “unknown”)
            if (patient.Age == 0)
            {
                var d = GetDefaultThreshold();
                return new VitalThresholds(d.Min, d.Max);
            }

            // Decision 3 (the helper contains the predicate and fallback)
            var config = FindConfigOrDefault(patient.Age);
            return new VitalThresholds(config.Min, config.Max);
        }

        private SimpleThresholdConfig GetDefaultThreshold()
        {
            var d = ThresholdConfig.Thresholds.LastOrDefault(); // or LastOrDefault()
            if (d == null)
                throw new InvalidOperationException("No threshold configurations are defined.");
            return d;
        }

        private SimpleThresholdConfig FindConfigOrDefault(int age)
        {
            var match = ThresholdConfig.Thresholds
                .FirstOrDefault(t => age >= t.MinAge && age <= t.MaxAge);

            if (match != null) return match;

            var d = ThresholdConfig.Thresholds.LastOrDefault(); // or LastOrDefault()
            if (d == null)
                throw new InvalidOperationException("No threshold configurations are defined.");
            return d;
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
