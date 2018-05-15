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
            getComponent();
            getMemory();
            getGraphicCard();
            getHDD();



            Console.ReadKey();
        }

        private static void getComponent()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

      
            foreach (ManagementObject mj in mos.Get())
            {
                Console.WriteLine("CPU Name : " + Convert.ToString(mj["Name"]));
                Console.WriteLine("Core : " + Convert.ToString(mj["NumberOfCores"]));
                Console.WriteLine("Thread : " + Convert.ToString(mj["ThreadCount"]));
                Console.WriteLine("Processorid : " + Convert.ToString(mj["Processorid"]));
            }
         

        }

        private static void getMemory()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            foreach (ManagementObject mj in mos.Get())
            {
               
                Console.WriteLine("Capacity : " + Convert.ToUInt64(mj["Capacity"])/(1024*1024*1024) + " GB");
                int memorytype = Convert.ToUInt16(mj["MemoryType"]);
                if (memorytype == 20)
                {
                    Console.WriteLine("Memory Type : DDR ");
                }
                else if (memorytype == 21)
                {
                    Console.WriteLine("Memory Type : DDR2 ");
                }
                else if (memorytype == 22)
                {
                    Console.WriteLine("Memory Type : DDR2 FB-DIMM ");
                }
                else if (memorytype == 24)
                {
                    Console.WriteLine("Memory Type : DDR3 ");
                }
                else if (memorytype == 25)
                {
                    Console.WriteLine("Memory Type : FBD2 ");
                }

            }

        }
        private static void getGraphicCard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

            foreach (ManagementObject mj in mos.Get())
            {
                Console.WriteLine("Graphic Card Name : " + Convert.ToString(mj["Caption"]));
                Console.WriteLine("Size Graphic Card : " + Convert.ToUInt64(mj["AdapterRAM"]) / (1024 * 1024 * 1024) + " GB");
            }
        }

        private static void getHDD()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject mj in mos.Get())
            {
                Console.WriteLine("DiskDrive Name : " + Convert.ToString(mj["Caption"]));
                Console.WriteLine("Size DiskDrive : " + (((Convert.ToUInt64(mj["Size"]) / 1024) / 1024)/1024) + " GB");
            }
        }




    }
}
