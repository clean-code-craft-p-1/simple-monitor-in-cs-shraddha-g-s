namespace checker
{
    public class SystolicBloodPressureVital : VitalSignBase
    {
        public override string Name => "Systolic Blood Pressure";
        public SystolicBloodPressureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
    }
}
