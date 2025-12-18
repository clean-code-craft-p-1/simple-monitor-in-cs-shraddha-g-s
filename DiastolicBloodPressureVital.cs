namespace checker
{
    public class DiastolicBloodPressureVital : VitalSignBase
    {
        public override string Name => "Diastolic Blood Pressure";
        public DiastolicBloodPressureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
        public override VitalThresholds GetThresholds(PatientDetails patientDetails)
        {
            if (patientDetails != null && patientDetails.Age < 13)
                return new VitalThresholds(ThresholdConfig.Child.Min, ThresholdConfig.Child.Max); // Children

            return new VitalThresholds(ThresholdConfig.Adult.Min, ThresholdConfig.Adult.Max);        // Adults
        }
    }

}
