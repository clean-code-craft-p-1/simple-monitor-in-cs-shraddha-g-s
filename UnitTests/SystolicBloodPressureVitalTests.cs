using Xunit;

namespace checker.UnitTests
{
    public class SystolicBloodPressureVitalTests
    {
        private static VitalThresholdConfig GetTestConfig()
        {
            // Use the helper to load the full config, then select the diastolic BP section
            return VitalTestHelper.LoadConfig().Systolic;
        }

        [Theory]
        [InlineData(110, 30, VitalLevel.Normal)]
        [InlineData(70, 30, VitalLevel.Low)]
        [InlineData(130, 30, VitalLevel.High)]
        [InlineData(90, 10, VitalLevel.Normal)]
        [InlineData(60, 10, VitalLevel.Low)]
        [InlineData(120, 10, VitalLevel.High)]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = GetTestConfig();
            var vital = new SystolicBloodPressureVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }
}
