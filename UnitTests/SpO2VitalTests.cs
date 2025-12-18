using Xunit;

namespace checker.UnitTests
{
    public class SpO2VitalTests : VitalTests<SpO2Vital>
    {
        protected override VitalThresholdConfig GetTestConfig() => VitalTestHelper.LoadConfig().SpO2;
        protected override SpO2Vital CreateVital(VitalThresholdConfig config) => new SpO2Vital(config);

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 98f, 30, VitalLevel.Normal };
            yield return new object[] { 90f, 30, VitalLevel.Low };
            yield return new object[] { 101f, 30, VitalLevel.High };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        => base.Check_ReturnsExpectedLevel_Impl(value, age, expected);
    }
}

