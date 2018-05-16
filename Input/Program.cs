using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using ConsoleApp1.Models;
namespace Input
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Input());
            getComputer();
            getMemory();
            getGraphicCard();
            getHDD();

        }

        private static void getComputer()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            Computer computer = new Computer();
            SendData sendData = new SendData();
            foreach (ManagementObject mj in mos.Get())
            {

                //Console.WriteLine("CPU Name : " + Convert.ToString(mj["Name"]));
                //Console.WriteLine("Core : " + Convert.ToString(mj["NumberOfCores"]));
                //Console.WriteLine("Thread : " + Convert.ToString(mj["ThreadCount"]));
                //Console.WriteLine("Processorid : " + Convert.ToString(mj["Processorid"]));
                computer.Cpuname = Convert.ToString(mj["Name"]);
                computer.Cores = Convert.ToInt32(mj["NumberOfCores"]);
                computer.Thread = Convert.ToInt32(mj["ThreadCount"]);
                computer.ProcessorId = Convert.ToString(mj["Processorid"]);
                sendData.CreateComputer(computer);
            }


        }

        private static void getMemory()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            Memory memory = new Memory();
            SendData sendData = new SendData();
            foreach (ManagementObject mj in mos.Get())
            {
                string memoryt = null;
                Console.WriteLine("Capacity : " + Convert.ToUInt64(mj["Capacity"]) / (1024 * 1024 * 1024) + " GB");
                int memorytype = Convert.ToUInt16(mj["MemoryType"]);
                if (memorytype == 20)
                {
                    //Console.WriteLine("Memory Type : DDR ");
                    memoryt = "DDR";
                }
                else if (memorytype == 21)
                {
                    //Console.WriteLine("Memory Type : DDR2 ");
                    memoryt = "DDR2";
                }
                else if (memorytype == 22)
                {
                    //Console.WriteLine("Memory Type : DDR2 FB-DIMM ");
                    memoryt = "DDR2 FB-DIMM";
                }
                else if (memorytype == 24)
                {
                    //Console.WriteLine("Memory Type : DDR3 ");
                    memoryt = "DDR3";
                }
                else if (memorytype == 25)
                {
                    //Console.WriteLine("Memory Type : FBD2 ");
                    memoryt = "FBD2";
                }
                memory.Capacity = Convert.ToInt32(Convert.ToUInt64(mj["Capacity"]) / (1024 * 1024 * 1024));
                memory.MemoryType = memoryt;
                sendData.CreateMemory(memory);
            }

        }
        private static void getGraphicCard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            GraphicCard graphicCard = new GraphicCard();
            SendData sendData = new SendData();
            foreach (ManagementObject mj in mos.Get())
            {
                Console.WriteLine("Graphic Card Name : " + Convert.ToString(mj["Caption"]));
                Console.WriteLine("Size Graphic Card : " + Convert.ToUInt64(mj["AdapterRAM"]) / (1024 * 1024 * 1024) + " GB");
                graphicCard.Caption = Convert.ToString(mj["Caption"]);
                graphicCard.AdapterRam = Convert.ToInt32(Convert.ToUInt64(mj["AdapterRAM"]) / (1024 * 1024 * 1024));
                sendData.CreateGraphicCard(graphicCard);
            }
        }

        private static void getHDD()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            DiskDrive diskDrive = new DiskDrive();
            SendData sendData = new SendData();
            foreach (ManagementObject mj in mos.Get())
            {
                //Console.WriteLine("DiskDrive Name : " + Convert.ToString(mj["Caption"]));
                //Console.WriteLine("Size DiskDrive : " + (((Convert.ToUInt64(mj["Size"]) / 1024) / 1024)/1024) + " GB");
                diskDrive.Caption = Convert.ToString(mj["Caption"]);
                diskDrive.Size = Convert.ToInt32(((Convert.ToUInt64(mj["Size"]) / 1024) / 1024) / 1024);
                sendData.CreateHDD(diskDrive);
            }
        }




    }
}
