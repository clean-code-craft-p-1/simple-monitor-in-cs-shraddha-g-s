namespace checker
{
    public class TemperatureVital : VitalSignBase
    {
        
        public override string Name => "Temperature";

        public TemperatureVital(VitalThresholdConfig config) : base(config) { }
    }
}

