using Xunit;
using System.Collections.Generic;

namespace checker.UnitTests
{
    public class AllVitalsTests
    {
        // Shared helper for test data
        private static IEnumerable<object[]> MakeTestData(params (float value, int age, VitalLevel expected)[] cases)
        {
            foreach (var c in cases)
                yield return new object[] { c.value, c.age, c.expected };
        }

        // Temperature tests
        public static IEnumerable<object[]> TemperatureTestData() => MakeTestData(
            (98.6f, 30, VitalLevel.Normal),
            (94f, 30, VitalLevel.Low),
            (103f, 30, VitalLevel.High),
            (98.6f, 10, VitalLevel.Normal),
            (94f, 10, VitalLevel.Low),
            (103f, 10, VitalLevel.High)
        );

        [Theory]
        [MemberData(nameof(TemperatureTestData))]
        public void Temperature_Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = VitalTestHelper.LoadConfig().Temperature;
            var vital = new TemperatureVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }

        // Pulse tests
        public static IEnumerable<object[]> PulseTestData() => MakeTestData(
            (70f, 30, VitalLevel.Normal),
            (50f, 30, VitalLevel.Low),
            (110f, 30, VitalLevel.High),
            (80f, 1, VitalLevel.Normal),
            (60f, 1, VitalLevel.Low),
            (120f, 1, VitalLevel.High)
        );

        [Theory]
        [MemberData(nameof(PulseTestData))]
        public void Pulse_Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = VitalTestHelper.LoadConfig().Pulse;
            var vital = new PulseVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }

        // SpO2 tests
        public static IEnumerable<object[]> SpO2TestData() => MakeTestData(
            (98f, 30, VitalLevel.Normal),
            (90f, 30, VitalLevel.Low),
            (101f, 30, VitalLevel.High)
        );

        [Theory]
        [MemberData(nameof(SpO2TestData))]
        public void SpO2_Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = VitalTestHelper.LoadConfig().SpO2;
            var vital = new SpO2Vital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }

        // Diastolic Blood Pressure tests
        public static IEnumerable<object[]> DiastolicTestData() => MakeTestData(
            (70f, 30, VitalLevel.Normal),
            (50f, 30, VitalLevel.Low),
            (90f, 30, VitalLevel.High),
            (60f, 10, VitalLevel.Normal),
            (40f, 10, VitalLevel.Low),
            (90f, 10, VitalLevel.High)
        );

        [Theory]
        [MemberData(nameof(DiastolicTestData))]
        public void Diastolic_Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = VitalTestHelper.LoadConfig().Diastolic;
            var vital = new DiastolicBloodPressureVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }

        // Systolic Blood Pressure tests
        public static IEnumerable<object[]> SystolicTestData() => MakeTestData(
            (110f, 30, VitalLevel.Normal),
            (70f, 30, VitalLevel.Low),
            (130f, 30, VitalLevel.High),
            (90f, 10, VitalLevel.Normal),
            (60f, 10, VitalLevel.Low),
            (120f, 10, VitalLevel.High)
        );

        [Theory]
        [MemberData(nameof(SystolicTestData))]
        public void Systolic_Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        {
            var config = VitalTestHelper.LoadConfig().Systolic;
            var vital = new SystolicBloodPressureVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }
}