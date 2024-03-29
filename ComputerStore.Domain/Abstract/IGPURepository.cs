﻿using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
    public interface IGPURepository
    {
        IEnumerable<GPU> GPUs { get; }
        void SaveChanges(GPU gpu);
        GPU DeleteProduct(int Id);
    }
}
