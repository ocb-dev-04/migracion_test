using DomainCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Core.Interfaces
{
    public interface ISolicitudesRep
    {
        Task<List<Solicitud>> GetAll();
        Task<Solicitud> GetById(int id);
        Task<bool> Create(Solicitud create);
        Task<bool> Update(int id , Solicitud create);
        Task<bool> Delete(int id);
    }
}
