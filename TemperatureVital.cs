namespace checker
{
    public class TemperatureVital : VitalSignBase
    {
        public override string Name => "Temperature";
        public TemperatureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }

        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            if (patientDetails != null && patientDetails.Age < 12)
                return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max);
            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);
        }
    }
}
