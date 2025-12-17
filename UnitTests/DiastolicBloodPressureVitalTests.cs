using Xunit;

namespace checker.UnitTests
{
    public class DiastolicBloodPressureVitalTests
    {
        private static VitalThresholdConfig GetTestConfig()
        {
            // Use the helper to load the full config, then select the diastolic BP section
            return VitalTestHelper.LoadConfig().Diastolic;
        }

        [Theory]
        [InlineData(70, 30, VitalLevel.Normal)]
        [InlineData(50, 30, VitalLevel.Low)]
        [InlineData(90, 30, VitalLevel.High)]
        [InlineData(60, 10, VitalLevel.Normal)]
        [InlineData(40, 10, VitalLevel.Low)]
        [InlineData(90, 10, VitalLevel.High)]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = GetTestConfig();
            var vital = new DiastolicBloodPressureVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }
}