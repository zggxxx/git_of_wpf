using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Common
{
    public class CPackageHelper
    {
        public byte[] UnPackage<T>(T packageHeader)
        {
            int len = Marshal.SizeOf(packageHeader);
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(packageHeader,ptr,true);
            byte[] buffer = new byte[len];
            Marshal.Copy(ptr, buffer,0,len);
            Marshal.FreeHGlobal(ptr);
            return buffer;
        }




        public byte[] PackData(byte[] data) 
        {
            Model.BatteryModel.PackageHeader header = new Model.BatteryModel.PackageHeader();
            for (int i = 0; i < 8; i++)
            {
                header.head = header.head << 8 | 0xEF;
            }
            header.length = (ushort)(data.Length + Marshal.SizeOf(header) - 6);
            byte[] headerData = UnPackage(header);
            byte[] buffer = new byte[header.length + 8];
            Array.Copy(headerData,0,buffer,0,headerData.Length);
            Array.Copy(data, 0, buffer, headerData.Length, data.Length);
            buffer[buffer.Length - 1] = 0xEF;
            buffer[buffer.Length - 2] = 0xEF;
            return buffer;
        }

    }
}
