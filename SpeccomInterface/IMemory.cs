﻿using SpeccomDB.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace SpeccomInterface
{
    public interface IMemory
    {
        IEnumerable<Memory> GetAllMemories();
        Memory GetMemoryByID(int id);
        void PutMemory(int id, Memory memory);
        void AddMemory(Memory memory);
    }
}
