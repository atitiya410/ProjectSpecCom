using System;
using System.Threading.Tasks;
using System.Management;
using SpeccomDB.Models;

namespace Input
{
    public class GetData
    {
            Computer computer = new Computer();
            SendData sendData = new SendData();
        
        
        public async Task getComputer()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
           
           
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
                await sendData.CreateComputer(computer);
                getMemory();
                getGraphicCard();
                getHDD();
                //getComuser();


            }


        }

        public async void getMemory()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

           
            foreach (ManagementObject mj in mos.Get())
            {
                Memory memory = new Memory();
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
                memory.ProcessorId = computer.ProcessorId;
                await sendData.CreateMemory(memory);
            }

        }
        public async void getGraphicCard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            
           
            foreach (ManagementObject mj in mos.Get())
            {
                GraphicCard graphicCard = new GraphicCard();
                Console.WriteLine("Graphic Card Name : " + Convert.ToString(mj["Caption"]));
                Console.WriteLine("Size Graphic Card : " + Convert.ToUInt64(mj["AdapterRAM"]) / (1024 * 1024 * 1024) + " GB");
                graphicCard.Caption = Convert.ToString(mj["Caption"]);
                graphicCard.AdapterRam = Convert.ToInt32(Convert.ToUInt64(mj["AdapterRAM"]) / (1024 * 1024 * 1024));
                graphicCard.ProcessorId = computer.ProcessorId;
                await sendData.CreateGraphicCard(graphicCard);
            }
        }

        public async void getHDD()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
           
           
            foreach (ManagementObject mj in mos.Get())
            {
                DiskDrive diskDrive = new DiskDrive();
                //Console.WriteLine("DiskDrive Name : " + Convert.ToString(mj["Caption"]));
                //Console.WriteLine("Size DiskDrive : " + (((Convert.ToUInt64(mj["Size"]) / 1024) / 1024)/1024) + " GB");
                diskDrive.Caption = Convert.ToString(mj["Caption"]);
                diskDrive.Size = Convert.ToInt32(((Convert.ToUInt64(mj["Size"]) / 1024) / 1024) / 1024);
                diskDrive.ProcessorId = computer.ProcessorId;
                await sendData.CreateHDD(diskDrive);
            }
        }

    }
}
