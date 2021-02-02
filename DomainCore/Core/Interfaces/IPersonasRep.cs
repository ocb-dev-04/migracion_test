using DomainCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Core.Interfaces
{
    public interface IPersonasRep
    {
        Task<List<Personas>> GetAll();
        Task<Personas> GetById(int id);
        Task<bool> Create(Personas create);
        Task<bool> Update(int id, Personas create);
        Task<bool> Delete(int id);
    }
}
