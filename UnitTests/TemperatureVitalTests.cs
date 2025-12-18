using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace checker.UnitTests
{
    public class TemperatureVitalTests : VitalTests<TemperatureVital>
    {
        protected override VitalThresholdConfig GetTestConfig() => VitalTestHelper.LoadConfig().Temperature;
        protected override TemperatureVital CreateVital(VitalThresholdConfig config) => new TemperatureVital(config);

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 98.6f, 30, VitalLevel.Normal };
            yield return new object[] { 94f, 30, VitalLevel.Low };
            yield return new object[] { 103f, 30, VitalLevel.High };
            yield return new object[] { 98.6f, 10, VitalLevel.Normal };
            yield return new object[] { 94f, 10, VitalLevel.Low };
            yield return new object[] { 103f, 10, VitalLevel.High };
        }
        
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        => base.Check_ReturnsExpectedLevel_Impl(value, age, expected);

    }
}
