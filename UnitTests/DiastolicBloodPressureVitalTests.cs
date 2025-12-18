using Xunit;

namespace checker.UnitTests
{
    public class DiastolicBloodPressureVitalTests : VitalTests<DiastolicBloodPressureVital>
    {
        protected override VitalThresholdConfig GetTestConfig() => VitalTestHelper.LoadConfig().Diastolic;
        protected override DiastolicBloodPressureVital CreateVital(VitalThresholdConfig config) => new DiastolicBloodPressureVital(config);

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 70f, 30, VitalLevel.Normal };
            yield return new object[] { 50f, 30, VitalLevel.Low };
            yield return new object[] { 90f, 30, VitalLevel.High };
            yield return new object[] { 60f, 10, VitalLevel.Normal };
            yield return new object[] { 40f, 10, VitalLevel.Low };
            yield return new object[] { 90f, 10, VitalLevel.High };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        => base.Check_ReturnsExpectedLevel_Impl(value, age, expected);
    }
}