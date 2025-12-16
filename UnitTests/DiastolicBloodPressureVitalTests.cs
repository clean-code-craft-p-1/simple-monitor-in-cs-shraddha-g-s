using Xunit;

namespace checker.Tests
{
    public class DiastolicBloodPressureVitalTests
    {
        [Fact]
        public void Check_ReturnsNormalForAdultNormalDBP()
        {
            var vital = new DiastolicBloodPressureVital();
            var result = vital.Check(75, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.Normal, result.Level);
        }

        [Fact]
        public void Check_ReturnsLowForAdultLowDBP()
        {
            var vital = new DiastolicBloodPressureVital();
            var result = vital.Check(50, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.Low, result.Level);
        }

        [Fact]
        public void Check_ReturnsHighForAdultHighDBP()
        {
            var vital = new DiastolicBloodPressureVital();
            var result = vital.Check(90, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.High, result.Level);
        }

        [Fact]
        public void GetThresholds_ReturnsChildThresholds()
        {
            var vital = new DiastolicBloodPressureVital();
            var thresholds = vital.GetThresholds(new PatientDetails { Age = 10 });
            Assert.Equal(50, thresholds.Min);
            Assert.Equal(80, thresholds.Max);
        }
    }
}
