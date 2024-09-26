using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Model
{

    public class BatteryModel
    {
        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public struct PackageHeader
        {
            public UInt64 head;
            public Byte version;
            public Byte seq;
            public UInt16 length;
            public Byte count;
        }
        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public struct SBatteryCCDCInfo
        {
            public Byte step;
            public double voltage;
            public double current;
            public double capacity;
            public double resistance;
        }

    }
}
