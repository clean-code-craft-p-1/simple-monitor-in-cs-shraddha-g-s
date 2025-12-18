using Xunit;
namespace checker.UnitTests
{
    public class SystolicBloodPressureVitalTests : VitalTests<SystolicBloodPressureVital>
    {
        protected override VitalThresholdConfig GetTestConfig() => VitalTestHelper.LoadConfig().Systolic;
        protected override SystolicBloodPressureVital CreateVital(VitalThresholdConfig config) => new SystolicBloodPressureVital(config);

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 110f, 30, VitalLevel.Normal };
            yield return new object[] { 70f, 30, VitalLevel.Low };
            yield return new object[] { 130f, 30, VitalLevel.High };
            yield return new object[] { 90f, 10, VitalLevel.Normal };
            yield return new object[] { 60f, 10, VitalLevel.Low };
            yield return new object[] { 120f, 10, VitalLevel.High };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Check_ReturnsExpectedLevel(float value, int age, VitalLevel expected)
        => base.Check_ReturnsExpectedLevel_Impl(value, age, expected);
    }

}
