using Xunit;

namespace checker.UnitTests
{
    public class SpO2VitalTests
    {
        private static VitalThresholdConfig GetTestConfig()
        {
            // Use the helper to load the full config, then select the diastolic BP section
            return VitalTestHelper.LoadConfig().SpO2;
        }

        [Theory]
        [InlineData(98, 30, VitalLevel.Normal)]
        [InlineData(90, 30, VitalLevel.Low)]
        [InlineData(101, 30, VitalLevel.High)]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = GetTestConfig();
            var vital = new SpO2Vital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }

        [Fact]
        public void GetThresholds_ReturnsExpected()
        {
            var config = GetTestConfig();
            var vital = new SpO2Vital(config);
            VitalTestHelper.AssertThresholds(vital, new PatientDetails { Age = 30 }, 95, 100);
        }
    }
}

