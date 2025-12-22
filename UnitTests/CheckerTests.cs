using Xunit;
using System.Collections.Generic;
using checker;

namespace Philips.checker.UnitTests
{
    public class CheckerTests
    {
        private readonly Checker _checker = new Checker();

        private static readonly PatientDetails DefaultPatient = new() { Age = 30 };

        public static IEnumerable<object[]> CheckAllTestCases()
        {
            yield return new object[] { 98.6f, 70, 98, 120, 80, true }; // all normal
            yield return new object[] { 101.5f, 70, 98, 120, 80, false }; // temperature high
        }

        public static IEnumerable<object[]> StatusMessageTestCases()
        {
            yield return new object[]
            {
                new List<VitalResult>
                {
                    new("Temperature", VitalLevel.Normal, "98.6"),
                    new("Pulse", VitalLevel.Normal, "70"),
                    new("SpO2", VitalLevel.Normal, "98"),
                    new("SystolicBloodPressure", VitalLevel.Normal,"120"),
                    new("DiastolicBloodPressure", VitalLevel.Normal,"80")
                },
                new[] { "Vitals received within normal range", "Temperature: 98.6 Pulse: 70 SpO2: 98 SystolicBloodPressure: 120 DiastolicBloodPressure: 80" }
            };
            yield return new object[]
            {
                new List<VitalResult>
                {
                    new("Temperature", VitalLevel.High, "102"),
                    new("Pulse", VitalLevel.Low, "110"),
                    new("SpO2", VitalLevel.Normal, "98"),
                    new("SystolicBloodPressure", VitalLevel.Low,"90"),
                    new("DiastolicBloodPressure", VitalLevel.Low,"50")
                },
                new[] { "Temperature: 102", "Pulse: 110", "SystolicBloodPressure: 90", "DiastolicBloodPressure: 50" }
            };
        }

        [Theory]
        [MemberData(nameof(CheckAllTestCases))]
        public void AllVitalsNormal_ChecksExpectedResult(float temp, int pulse, int spo2, int sys, int dia, bool expected)
        {
            var results = _checker.CheckAll(temp, pulse, spo2, sys, dia, DefaultPatient);
            Assert.Equal(5, results.Count);
            Assert.Equal(expected, _checker.AllVitalsNormal(results));
        }

        [Theory]
        [MemberData(nameof(StatusMessageTestCases))]
        public void GetVitalsStatusMessages_ReturnsExpectedMessages(List<VitalResult> input, string[] expectedMessages)
        {
            var messages = _checker.GetVitalsStatusMessages(input);
            for (int i = 0; i < expectedMessages.Length; i++)
            {
                Assert.Contains(expectedMessages[i], messages[i]);
            }
        }
    }
}
