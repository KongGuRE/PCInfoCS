using System.Dynamic;
using System.Management;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComputerInformation
{
    public class HardwareInformation
    {
        public static double[] WindowGetTotalPhysicalMemory()
        {
            List<double> memoryList = new List<double>();
            using (ManagementObjectSearcher win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"))
            {
                foreach (ManagementObject? obj in win32CompSys.Get().Cast<ManagementObject>())
                {
                    string? sTotalphysicalmemory = obj["totalphysicalmemory"]?.ToString();
                    if (double.TryParse(sTotalphysicalmemory, out double lTotalphysicalmemory))
                    {
                        Console.WriteLine(FormatBytetoGB(lTotalphysicalmemory));
                        memoryList.Add(FormatBytetoGB(lTotalphysicalmemory));
                    }
                }
            }
            return memoryList.ToArray();
        }

        public static double FormatBytetoGB (double obj)
        {
            const int scale = 1024;
            if (double.TryParse(obj.ToString(), out double formatData))
                for (int i = 0; i < 3; i++)
                    formatData /= scale;
            return formatData;
        }
    }
}