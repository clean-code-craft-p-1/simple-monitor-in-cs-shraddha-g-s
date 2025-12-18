using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace checker.UnitTests
{
  
    public abstract class VitalTests<TVital> where TVital : IVitalSign
    {
        protected abstract VitalThresholdConfig GetTestConfig();
        protected abstract TVital CreateVital(VitalThresholdConfig config);

        // Common logic here
        protected void Check_ReturnsExpectedLevel_Impl(float value, int age, VitalLevel expected)
        {
            var config = GetTestConfig();
            var vital = CreateVital(config);
            VitalTestHelper.AssertVitalLevel(vital, value, new PatientDetails { Age = age }, expected);
        }
    }

}
