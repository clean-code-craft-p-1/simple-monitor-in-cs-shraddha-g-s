using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace checker.UnitTests
{
    public class PulseVitalTests : VitalTests<PulseVital>
    {
        protected override VitalThresholdConfig GetTestConfig() => VitalTestHelper.LoadConfig().Pulse;
        protected override PulseVital CreateVital(VitalThresholdConfig config) => new PulseVital(config);

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 70f, 30, VitalLevel.Normal };
            yield return new object[] { 50f, 30, VitalLevel.Low };
            yield return new object[] { 110f, 30, VitalLevel.High };
            yield return new object[] { 80f, 1, VitalLevel.Normal };
            yield return new object[] { 60f, 1, VitalLevel.Low };
            yield return new object[] { 120f, 1, VitalLevel.High };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        => base.Check_ReturnsExpectedLevel_Impl(value, age, expected);
    }
}


