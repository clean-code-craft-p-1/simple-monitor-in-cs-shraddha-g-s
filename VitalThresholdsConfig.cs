namespace checker
{
    public class VitalThresholdsConfig
    {
        public VitalThresholdConfig Temperature { get; set; }
        public VitalThresholdConfig Pulse { get; set; }
        public VitalThresholdConfig SpO2 { get; set; }
        public VitalThresholdConfig Diastolic { get; set; }
        public VitalThresholdConfig Systolic { get; set; }
    }
}
