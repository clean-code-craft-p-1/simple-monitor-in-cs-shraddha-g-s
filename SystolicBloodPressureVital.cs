namespace checker
{
    public class SystolicBloodPressureVital : VitalSignBase
    {
        public override string Name => "Systolic Blood Pressure";
        public SystolicBloodPressureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            if (patientDetails != null && patientDetails.Age < 13)
                return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max); // Children

            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);        // Adults
        }
    }
}
