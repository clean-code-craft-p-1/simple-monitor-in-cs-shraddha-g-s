using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    public class VitalThresholdConfig
    {
        public SimpleThresholdConfig Child { get; set; }
        public SimpleThresholdConfig Adult { get; set; }
    }
}
