using DomainCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Core.Interfaces
{
    public interface IEstadosRep
    {
        Task<List<Estado>> GetAll();
        Task<Estado> GetByName(string name);
        Task<Estado> GetById(int id);
        Task<bool> Create(Estado create);
        Task<bool> Update(int id, Estado create);
        Task<bool> Delete(int id);
    }
}
