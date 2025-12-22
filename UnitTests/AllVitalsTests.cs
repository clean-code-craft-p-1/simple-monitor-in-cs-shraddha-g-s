using Xunit;
using System;
using System.Collections.Generic;

namespace checker.UnitTests
{
    public class AllVitalsTests
    {
        public static IEnumerable<object[]> AllVitalsTestData()
        {
            // name, value, age, expected
            yield return new object[] { "Temperature", 98.6f, 30, VitalLevel.Normal };
            yield return new object[] { "Temperature", 94f, 30, VitalLevel.Low };
            yield return new object[] { "Temperature", 103f, 30, VitalLevel.High };
            yield return new object[] { "Temperature", 98.6f, 10, VitalLevel.Normal };
            yield return new object[] { "Temperature", 94f, 10, VitalLevel.Low };
            yield return new object[] { "Temperature", 103f, 10, VitalLevel.High };

            yield return new object[] { "Pulse", 70f, 30, VitalLevel.Normal };
            yield return new object[] { "Pulse", 50f, 30, VitalLevel.Low };
            yield return new object[] { "Pulse", 110f, 30, VitalLevel.High };
            yield return new object[] { "Pulse", 80f, 1, VitalLevel.Normal };
            yield return new object[] { "Pulse", 60f, 1, VitalLevel.Low };
            yield return new object[] { "Pulse", 120f, 1, VitalLevel.High };

            yield return new object[] { "SpO2", 98f, 30, VitalLevel.Normal };
            yield return new object[] { "SpO2", 90f, 30, VitalLevel.Low };
            yield return new object[] { "SpO2", 101f, 30, VitalLevel.High };

            yield return new object[] { "Diastolic", 70f, 30, VitalLevel.Normal };
            yield return new object[] { "Diastolic", 50f, 30, VitalLevel.Low };
            yield return new object[] { "Diastolic", 90f, 30, VitalLevel.High };
            yield return new object[] { "Diastolic", 60f, 10, VitalLevel.Normal };
            yield return new object[] { "Diastolic", 40f, 10, VitalLevel.Low };
            yield return new object[] { "Diastolic", 90f, 10, VitalLevel.High };

            yield return new object[] { "Systolic", 110f, 30, VitalLevel.Normal };
            yield return new object[] { "Systolic", 70f, 30, VitalLevel.Low };
            yield return new object[] { "Systolic", 130f, 30, VitalLevel.High };
            yield return new object[] { "Systolic", 90f, 10, VitalLevel.Normal };
            yield return new object[] { "Systolic", 60f, 10, VitalLevel.Low };
            yield return new object[] { "Systolic", 120f, 10, VitalLevel.High };
        }

        [Theory]
        [MemberData(nameof(AllVitalsTestData))]
        public void AllVitals_Check_ReturnsExpectedLevel(string vitalName, float value, int age, VitalLevel expected)
        {
            var config = VitalTestHelper.LoadConfig();
            IVitalSign vital = vitalName switch
            {
                "Temperature" => new TemperatureVital(config.Temperature),
                "Pulse" => new PulseVital(config.Pulse),
                "SpO2" => new SpO2Vital(config.SpO2),
                "Diastolic" => new DiastolicBloodPressureVital(config.Diastolic),
                "Systolic" => new SystolicBloodPressureVital(config.Systolic),
                _ => throw new ArgumentException("Unknown vital name")
            };
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }
}
