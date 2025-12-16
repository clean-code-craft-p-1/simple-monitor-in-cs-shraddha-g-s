using Xunit;

namespace checker.Tests
{
    public class Spo2VitalTests
    {
        [Fact]
        public void Check_ReturnsNormalForNormalSpO2()
        {
            var vital = new Spo2Vital();
            var result = vital.Check(98, null);
            Assert.Equal(VitalLevel.Normal, result.Level);
        }

        [Fact]
        public void Check_ReturnsLowForLowSpO2()
        {
            var vital = new Spo2Vital();
            var result = vital.Check(90, null);
            Assert.Equal(VitalLevel.Low, result.Level);
        }

        [Fact]
        public void Check_ReturnsHighForHighSpO2()
        {
            var vital = new Spo2Vital();
            var result = vital.Check(101, null);
            Assert.Equal(VitalLevel.High, result.Level);
        }

        [Fact]
        public void GetThresholds_ReturnsCorrectThresholds()
        {
            var vital = new Spo2Vital();
            var thresholds = vital.GetThresholds(null);
            Assert.Equal(95, thresholds.Min);
            Assert.Equal(100, thresholds.Max);
        }
    }
}

