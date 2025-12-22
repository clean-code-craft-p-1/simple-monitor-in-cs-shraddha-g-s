namespace checker
{
    public class PulseVital : VitalSignBase
    {
        public override string Name => "Pulse Rate";
        public PulseVital(VitalThresholdConfig thresholdConfig)
        : base(thresholdConfig) { }
    }
}
