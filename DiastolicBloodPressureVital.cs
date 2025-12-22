namespace checker
{
    public class DiastolicBloodPressureVital : VitalSignBase
    {
        public override string Name => "Diastolic Blood Pressure";
        public DiastolicBloodPressureVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
    }

}
