using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace checker.UnitTests
{
    public class PulseVitalTests
    {
        private static VitalThresholdConfig GetTestConfig()
        {
            // Use the helper to load the full config, then select the diastolic BP section
            return VitalTestHelper.LoadConfig().Pulse;
        }

        [Theory]
        [InlineData(70, 30, VitalLevel.Normal)]
        [InlineData(50, 30, VitalLevel.Low)]
        [InlineData(110, 30, VitalLevel.High)]
        [InlineData(80, 1, VitalLevel.Normal)]
        [InlineData(60, 1, VitalLevel.Low)]
        [InlineData(120, 1, VitalLevel.High)]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = GetTestConfig();
            var vital = new PulseVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }
}


