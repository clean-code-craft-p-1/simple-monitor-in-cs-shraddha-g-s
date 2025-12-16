using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class VitalThresholds
    {
        public float Min { get; }
        public float Max { get; }

        public VitalThresholds(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}
