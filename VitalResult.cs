namespace checker
{
    public enum VitalLevel
    {
        Low,
        Normal,
        High
    }

    public class VitalResult
    {
        public string Name { get; }
        public VitalLevel Level { get; }
        public string Status { get; }

        public VitalResult(string name, VitalLevel level, string issue = null)
        {
            Name = name;
            Level = level;
            Status = issue;
        }
    }
}
