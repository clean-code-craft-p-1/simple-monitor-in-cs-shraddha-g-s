namespace checker
{
    public class PulseVital : VitalSignBase
    {
        public override string Name => "Pulse Rate";
        public PulseVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }

        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            if (patientDetails != null && patientDetails.Age < 2)
                return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max); // Infant

            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max); // Adult
        }
    }
}
