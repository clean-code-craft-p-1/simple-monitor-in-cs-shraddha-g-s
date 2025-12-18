using Xunit;

namespace checker.UnitTests
{
    public class CheckerTests
    {
        private readonly Checker _checker = new Checker();

        private List<VitalResult> AllNormalResults() => new()
        {
            new VitalResult("Temperature", VitalLevel.Normal, "98.6"),
            new VitalResult("Pulse", VitalLevel.Normal, "70"),
            new VitalResult("SpO2", VitalLevel.Normal, "98")
        };

        private List<VitalResult> MultipleAbnormalResults() => new()
        {
            new VitalResult("Temperature", VitalLevel.High, "High"),
            new VitalResult("Pulse", VitalLevel.Low, "Low"),
            new VitalResult("SpO2", VitalLevel.Normal, "98")
        };

        [Fact]
        public void CheckAll_ReturnsCorrectNumberOfResults()
        {
            var results = _checker.CheckAll(98.6f, 70, 98, 120, 80, new PatientDetails { Age = 30 });
            Assert.Equal(5, results.Count); // Assuming 5 vitals checked
        }

        [Fact]
        public void AllVitalsNormal_ReturnsTrueWhenAllNormal()
        {
            var results = _checker.CheckAll(98.6f, 70, 98, 120, 80, new PatientDetails { Age = 30 });
            Assert.True(_checker.AllVitalsNormal(results));
        }

        [Fact]
        public void AllVitalsNormal_ReturnsFalseWhenAnyIsAbnormal()
        {
            var results = _checker.CheckAll(101.5f, 70, 98, 120, 80, new PatientDetails { Age = 30 });
            Assert.False(_checker.AllVitalsNormal(results));
        }

        [Fact]
        public void GetVitalsStatusMessages_ReturnsNormalMessage_WhenAllNormal()
        {
            var messages = _checker.GetVitalsStatusMessages(AllNormalResults());
            Assert.Contains("Vitals received within normal range", messages[0]);
            Assert.Contains("Temperature: 98.6", messages[1]);
            Assert.Contains("Pulse: 70", messages[1]);
            Assert.Contains("SpO2: 98", messages[1]);
        }

        [Fact]
        public void GetVitalsStatusMessages_ReturnsMultipleAbnormalMessages_WhenMultipleAbnormal()
        {
            var messages = _checker.GetVitalsStatusMessages(MultipleAbnormalResults());
            Assert.Equal(2, messages.Count);
            Assert.Contains("Temperature: High", messages[0]);
            Assert.Contains("Pulse: Low", messages[1]);
        }
    }
}

