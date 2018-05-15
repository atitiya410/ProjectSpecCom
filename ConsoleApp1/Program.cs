using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }

        private static void getCPU()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject mj in mos.Get())
            {
                Convert.ToString(mj["Name"]);
                Convert.ToString(mj["MaxClockSpeed"]);
            }
        }

        private static void getMemory()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject mj in mos.Get())
            {
                Convert.ToString(mj["Name"]);
                Convert.ToString(mj["MaxClockSpeed"]);
            }
        }
    }
}
