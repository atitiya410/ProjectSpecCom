using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    public class Services
    {
        #region get Data

        public Computer GetComputer()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            DateTime now = DateTime.Now;
            Computer computer = new Computer();
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
                computer.LastUpdate = now;
            }
            return computer;

        }
        public List<Memory> GetMemory()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            List<Memory> memories = new List<Memory>();
            foreach (ManagementObject mj in mos.Get())
            {
                Memory memory = new Memory();
                string memoryt = null;
                Console.WriteLine("Capacity : " + Convert.ToUInt64(mj["Capacity"]) / (1000 * 1000 * 1000) + " GB");
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
                memory.Capacity = Convert.ToInt32(Convert.ToUInt64(mj["Capacity"]) / (1000 * 1000 * 1000));
                memory.MemoryType = memoryt;
                memories.Add(memory);
                
            }
            return memories;

        }
        public List<GraphicCard> getGraphicCard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            

            List<GraphicCard> graphicCards = new List<GraphicCard>();
            foreach (ManagementObject mj in mos.Get())
            {
                GraphicCard graphicCard = new GraphicCard();
                Console.WriteLine("Graphic Card Name : " + Convert.ToString(mj["Caption"]));
                Console.WriteLine("Size Graphic Card : " + Convert.ToUInt64(mj["AdapterRAM"]) / (1000 * 1000 * 1000) + " GB");
                graphicCard.Caption = Convert.ToString(mj["Caption"]);
                graphicCard.AdapterRam = Convert.ToInt32(Convert.ToUInt64(mj["AdapterRAM"]) / (1000 * 1000 * 1000));
                graphicCards.Add(graphicCard);

            }
            return graphicCards;
        }
        public List<DiskDrive> GetDiskDrive()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            List<DiskDrive> diskDrives = new List<DiskDrive>();

            foreach (ManagementObject mj in mos.Get())
            {
                DiskDrive diskDrive = new DiskDrive();
                //Console.WriteLine("DiskDrive Name : " + Convert.ToString(mj["Caption"]));
                //Console.WriteLine("Size DiskDrive : " + (((Convert.ToUInt64(mj["Size"]) / 1024) / 1024)/1024) + " GB");
                diskDrive.Caption = Convert.ToString(mj["Caption"]);
                diskDrive.Size = Convert.ToInt32(((Convert.ToUInt64(mj["Size"]) / 1000) / 1000) / 1000);
                diskDrives.Add(diskDrive);
            }

            return diskDrives;
        }
        #endregion


    }
}
