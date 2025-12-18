namespace checker
{
    public interface IVitalSign
    {
        public string Name { get; }
        public VitalThresholds GetThresholds(PatientDetails patientDetail);

        public VitalResult Check(float value, PatientDetails patientDetail = null);
    }

}
