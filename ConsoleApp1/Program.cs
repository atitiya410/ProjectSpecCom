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
            // ************** CPU Name **************
            Console.Write("Win32_Processor-Name : ");
            getComponent("Win32_Processor", "Name");  // Intel(R) Core(TM) i3 - 3227U CPU @ 1.90GHz

           //
           // ******************************************************************
           // ************** Generation **************
            Console.Write("Generation : ");


            //
            // ******************************************************************
            // ************** Speed **************
            Console.Write("Win32_Processor-Speed : ");
            getComponent("Win32_Processor", "CurrentClockSpeed");


            //
            // ******************************************************************
            // ************** Memory slot **************
            Console.Write("Win32_PhysicalMemory-Memory Slot : ");
            getComponent("Win32_PhysicalMemory", "Capacity");

            //
            // ******************************************************************
            // ************** MemoryType **************
            Console.Write("Win32_PhysicalMemory-MemoryType : ");
            getComponent("Win32_PhysicalMemory", "MemoryType");

            //
            // ******************************************************************
            // **************  Current Memory GB **************
            Console.Write("Win32_Processor-Name : ");


            //
            // ******************************************************************
            // ************** HDD **************
            Console.Write("Win32_DiskDrive-SizeHDD : ");
            getComponent("Win32_DiskDrive", "Size"); //500GB

            //
            // ******************************************************************
            // ************** Owner **************
            Console.Write("Win32_Processor-SystemName : ");
            getComponent("Win32_Processor","SystemName");

            //
            // ******************************************************************
            // ************** Caption **************
            Console.Write("Win32_VideoController-Caption : ");
            getComponent("Win32_VideoController", "Caption");





            Console.ReadKey();
        }

        private static void getComponent(string hwclass, string syntax)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM " + hwclass);

         

            foreach (ManagementObject mj in mos.Get())
            {
                Console.WriteLine(Convert.ToString(mj[syntax]));
             

            }
         

        }
    }
}
