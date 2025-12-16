using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    using Xunit;

    namespace checker.Tests
    {
        public class PulseVitalTests
        {
            [Fact]
            public void Check_ReturnsNormalForAdultNormalPulse()
            {
                var vital = new PulseVital();
                var result = vital.Check(70, new PatientDetails { Age = 30 });
                Assert.Equal(VitalLevel.Normal, result.Level);
            }

            [Fact]
            public void Check_ReturnsLowForAdultLowPulse()
            {
                var vital = new PulseVital();
                var result = vital.Check(50, new PatientDetails { Age = 30 });
                Assert.Equal(VitalLevel.Low, result.Level);
            }

            [Fact]
            public void Check_ReturnsHighForAdultHighPulse()
            {
                var vital = new PulseVital();
                var result = vital.Check(110, new PatientDetails { Age = 30 });
                Assert.Equal(VitalLevel.High, result.Level);
            }

            [Fact]
            public void GetThresholds_ReturnsInfantThresholds()
            {
                var vital = new PulseVital();
                var thresholds = vital.GetThresholds(new PatientDetails { Age = 0 });
                Assert.Equal(80, thresholds.Min);
                Assert.Equal(160, thresholds.Max);
            }
        }
    }

}
