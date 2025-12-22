namespace checker
{
    public class SpO2Vital : VitalSignBase
    {
        public override string Name => "SpO2";
        public SpO2Vital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
    }
}
