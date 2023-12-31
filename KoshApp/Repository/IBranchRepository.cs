﻿using KoshApp.Models;

namespace KoshApp.Repository
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllAsync();
        Task<Branch> GetByIdAsync(Int64 id);
        Task Create(Branch _Branch);
        Task Update(Branch _Branch);
        Task Delete(Int64 id);
    }
}
