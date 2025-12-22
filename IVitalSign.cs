namespace checker
{
    public interface IVitalSign
    {
        string Name { get; }
        VitalResult Check(float value, PatientDetails patient = null);
        VitalThresholds GetThresholds(PatientDetails patient);
        string GetLowMessage();
        string GetHighMessage();
        string GetNormalMessage();
    }

}
