using System.Text.Json;
using Xunit;

namespace checker.UnitTests
{
    public static class VitalTestHelper
    {
        public static VitalThresholdsConfig LoadConfig()
        {
            var configJson = File.ReadAllText("VitalThresholdsconfig.json");
            if (string.IsNullOrWhiteSpace(configJson))
                throw new System.InvalidOperationException("Config file is empty or missing.");

            var config = JsonSerializer.Deserialize<VitalThresholdsConfig>(configJson);
            if (config == null)
                throw new System.InvalidOperationException("Failed to deserialize vital thresholds config.");

            return config;
        }
        public static void AssertVitalLevel<TVital>(
            TVital vital, float value, PatientDetails patient, VitalLevel expected)
            where TVital : IVitalSign
        {
            var result = vital.Check(value, patient);
            Assert.Equal(expected, result.Level);
        }

        public static void AssertThresholds(
            IVitalSign vital, PatientDetails patient, float expectedMin, float expectedMax)
        {
            var thresholds = vital.GetThresholds(patient);
            Assert.Equal(expectedMin, thresholds.Min);
            Assert.Equal(expectedMax, thresholds.Max);
        }
    }
}
