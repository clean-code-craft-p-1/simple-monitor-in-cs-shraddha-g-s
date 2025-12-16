using Xunit;

namespace checker.Tests
{
    public class SystolicBloodPressureVitalTests
    {
        [Fact]
        public void Check_ReturnsNormalForAdultNormalSBP()
        {
            var vital = new SystolicBloodPressureVital();
            var result = vital.Check(110, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.Normal, result.Level);
        }

        [Fact]
        public void Check_ReturnsLowForAdultLowSBP()
        {
            var vital = new SystolicBloodPressureVital();
            var result = vital.Check(80, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.Low, result.Level);
        }

        [Fact]
        public void Check_ReturnsHighForAdultHighSBP()
        {
            var vital = new SystolicBloodPressureVital();
            var result = vital.Check(130, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.High, result.Level);
        }

        [Fact]
        public void GetThresholds_ReturnsChildThresholds()
        {
            var vital = new SystolicBloodPressureVital();
            var thresholds = vital.GetThresholds(new PatientDetails { Age = 10 });
            Assert.Equal(80, thresholds.Min);
            Assert.Equal(115, thresholds.Max);
        }
    }
}
