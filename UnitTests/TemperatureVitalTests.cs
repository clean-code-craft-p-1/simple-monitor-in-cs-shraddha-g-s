using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace checker.UnitTests
{
    public class TemperatureVitalTests
    {
        private static VitalThresholdConfig GetTestConfig()
        {
            // Use the helper to load the full config, then select the temperature section
            return VitalTestHelper.LoadConfig().Temperature;
        }

        [Theory]
        [InlineData(98.6f, 30, VitalLevel.Normal)]
        [InlineData(94f, 30, VitalLevel.Low)]
        [InlineData(103f, 30, VitalLevel.High)]
        [InlineData(98.6f, 10, VitalLevel.Normal)]
        [InlineData(94f, 10, VitalLevel.Low)]
        [InlineData(103f, 10, VitalLevel.High)]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = GetTestConfig();
            var vital = new TemperatureVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }
}
