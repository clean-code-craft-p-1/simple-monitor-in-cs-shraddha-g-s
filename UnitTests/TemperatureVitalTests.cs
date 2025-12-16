using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace checker.UnitTests
{
    public class TemperatureVitalTests
    {
        [Fact]
        public void Check_ReturnsNormalForNormalTemperature()
        {
            var vital = new TemperatureVital();
            var result = vital.Check(98.6f, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.Normal, result.Level);
        }

        [Fact]
        public void Check_ReturnsLowForLowTemperature()
        {
            var vital = new TemperatureVital();
            var result = vital.Check(94f, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.Low, result.Level);
        }

        [Fact]
        public void Check_ReturnsHighForHighTemperature()
        {
            var vital = new TemperatureVital();
            var result = vital.Check(103f, new PatientDetails { Age = 30 });
            Assert.Equal(VitalLevel.High, result.Level);
        }
    }

}
