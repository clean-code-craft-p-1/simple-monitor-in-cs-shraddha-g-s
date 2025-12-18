namespace checker
{
    public class VitalThresholds
    {
        public float Min { get; }
        public float Max { get; }

        public VitalThresholds(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}
