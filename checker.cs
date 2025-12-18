using System.Text.Json;

namespace checker
{
    public class Checker
    {
        private readonly VitalThresholdsConfig _thresholds;

        public Checker()
        {
            // Load and bind config file
            var configJson = File.ReadAllText("VitalThresholdsconfig.json");
            _thresholds = JsonSerializer.Deserialize<VitalThresholdsConfig>(configJson)
                ?? throw new InvalidOperationException("Failed to load vital thresholds config.");
        }

        public List<VitalResult> CheckAll(
            float temperature,
            int pulseRate,
            int spo2,
            int systolic,
            int diastolic,
            PatientDetails? patient = null)
        {
            var results = new List<VitalResult>
            {
                new TemperatureVital(_thresholds.Temperature).Check(temperature, patient),
                new PulseVital(_thresholds.Pulse).Check(pulseRate, patient),
                new SpO2Vital(_thresholds.SpO2).Check(spo2, patient),
                new SystolicBloodPressureVital(_thresholds.Systolic).Check(systolic, patient),
                new DiastolicBloodPressureVital(_thresholds.Diastolic).Check(diastolic, patient)
            };
            return results;
        }

        public bool AllVitalsNormal(List<VitalResult> results)
        {
            return results.All(r => r.Level == VitalLevel.Normal);
        }

        public List<string> GetVitalsStatusMessages(List<VitalResult> results)
        {
            var messages = results
                .Where(r => r.Level != VitalLevel.Normal)
                .Select(r => $"*********\n{r.Name}: {r.Status}\n**********")
                .ToList();

            if (!messages.Any())
            {
                messages.Add("Vitals received within normal range");
                var summary = string.Join(" ", results.Select(r => $"{r.Name}: {r.Status}"));
                messages.Add(summary);
            }

            return messages;
        }
    }
}
