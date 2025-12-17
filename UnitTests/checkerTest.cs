using Xunit;
using checker;
using System.Collections.Generic;

namespace checker.UnitTests
{
    public class CheckerTests
    {

        [Fact]
        public void CheckAll_ReturnsCorrectNumberOfResults()
        {
            var checker = new Checker();
            var results = checker.CheckAll(98.6f, 70, 98, 120, 80, new PatientDetails { Age = 30 });
            Assert.Equal(5, results.Count); // Assuming 5 vitals checked
        }

        [Fact]
        public void AllVitalsNormal_ReturnsTrueWhenAllNormal()
        {
            var checker = new Checker();
            var results = checker.CheckAll(98.6f, 70, 98, 120, 80, new PatientDetails { Age = 30 });
            Assert.True(checker.AllVitalsNormal(results));
        }

        [Fact]
        public void AllVitalsNormal_ReturnsFalseWhenAnyIsAbnormal()
        {
            var checker = new Checker();
            var results = checker.CheckAll(101.5f, 70, 98, 120, 80, new PatientDetails { Age = 30 });
            Assert.False(checker.AllVitalsNormal(results));
        }

        [Fact]
        public void GetVitalsStatusMessages_ReturnsNormalMessage_WhenAllNormal()
        {
            var checker = new Checker();
            var results = new List<VitalResult>
            {
                new VitalResult("Temperature", VitalLevel.Normal, "98.6"),
                new VitalResult("Pulse", VitalLevel.Normal, "70"),
                new VitalResult("SpO2", VitalLevel.Normal, "98")
            };

            var messages = checker.GetVitalsStatusMessages(results);

            Assert.Contains("Vitals received within normal range", messages[0]);
            Assert.Contains("Temperature: 98.6", messages[1]);
            Assert.Contains("Pulse: 70", messages[1]);
            Assert.Contains("SpO2: 98", messages[1]);
        }

        [Fact]
        public void GetVitalsStatusMessages_ReturnsMultipleAbnormalMessages_WhenMultipleAbnormal()
        {
            var checker = new Checker();
            var results = new List<VitalResult>
            {
                new VitalResult("Temperature", VitalLevel.High, "High"),
                new VitalResult("Pulse", VitalLevel.Low, "Low"),
                new VitalResult("SpO2", VitalLevel.Normal, "98")
            };

            var messages = checker.GetVitalsStatusMessages(results);

            Assert.Equal(2, messages.Count);
            Assert.Contains("Temperature: High", messages[0]);
            Assert.Contains("Pulse: Low", messages[1]);
        }
    }
}
