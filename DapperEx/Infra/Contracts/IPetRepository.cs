using DapperEx.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperEx.Infra.Contracts
{
    public interface IPetRepository
    {
        Task AddAsync(Pet pet);
        Task<Pet> GetByIdAsync(Guid id);
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> Update(Pet pet);
        Task<Pet> Delete(Guid id);
    }
}
