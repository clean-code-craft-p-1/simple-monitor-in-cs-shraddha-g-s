using System;
using System.Diagnostics;
namespace checker
{

    /*class Checker
    {
        public static bool VitalsOk(float temperature, int pulseRate, int spo2)
        {
            if(temperature >102 || temperature < 95)
            {
                Console.WriteLine("Temperature critical!");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("\r* ");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write("\r *");
                    System.Threading.Thread.Sleep(1000);
                }
                return false;
            }
            else if (pulseRate < 60 || pulseRate > 100)
            {
                Console.WriteLine("Pulse Rate is out of range!");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("\r* ");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write("\r *");
                    System.Threading.Thread.Sleep(1000);
                }
                return false;
            }
            else if (spo2 < 90)
            {
                Console.WriteLine("Oxygen Saturation out of range!");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("\r* ");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write("\r *");
                    System.Threading.Thread.Sleep(1000);
                }
                return false;
            }
            Console.WriteLine("Vitals received within normal range");
            Console.WriteLine("Temperature: {0} Pulse: {1}, SO2: {2}", temperature, pulseRate, spo2);
            return true;
        }
    }*/


    public class Checker
    {
        public static List<VitalResult> CheckAll(
            float temperature,
            int pulseRate,
            int spo2,
            int systolic,
            int diastolic,
            PatientDetails patient = null)
        {
            var results = new List<VitalResult>
            {
                new TemperatureVital().Check(temperature, patient),
                new PulseVital().Check(pulseRate, patient),
                new Spo2Vital().Check(spo2, patient),
                new SystolicBloodPressureVital().Check(systolic, patient),
                new DiastolicBloodPressureVital().Check(diastolic, patient)
            };
            return results;
        }


        public static bool AllVitalsNormal(List<VitalResult> results)
        {
            return results.All(r => r.Level == VitalLevel.Normal);
        }


        public static List<string> GetVitalsStatusMessages(List<VitalResult> results)
        {
            var messages = results
                .Where(r => r.Level != VitalLevel.Normal)
                .Select(r => $"*********\n{r.Name}: {r.Status}\n**********")
                .ToList();

            if (!messages.Any())
            {
                messages.Add("Vitals received within normal range");
                // Dynamically build the summary from all results
                var summary = string.Join(" ", results.Select(r => $"{r.Name}: {r.Status}"));
                messages.Add(summary);
            }

            return messages;
        }
    }
}

