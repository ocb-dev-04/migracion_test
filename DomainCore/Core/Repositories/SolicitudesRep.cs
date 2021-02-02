using DomainCore.Core.Interfaces;
using DomainCore.Data.Context;
using DomainCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Core.Repositories
{
    public class SolicitudesRep : ISolicitudesRep
    {
        private readonly AppDbContext _context;
        public SolicitudesRep(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Solicitud>> GetAll()
            => await _context.Solicitud.ToListAsync();

        public async Task<Solicitud> GetById(int id)
            => await _context.Solicitud.FirstOrDefaultAsync(f => f.Id == id);

        public async Task<bool> Create(Solicitud create)
        {
            var add = await _context.Solicitud.AddAsync(create);
            if (add == null) return false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Solicitud create)
        {
            _context.Entry(create).State = EntityState.Modified;
            var saved = await _context.SaveChangesAsync();
            if (saved == 0) return false;

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var Solicitud = await _context.Solicitud.FindAsync(id);
            if (Solicitud == null) return false;

            _context.Solicitud.Remove(Solicitud);
            var deleted = await _context.SaveChangesAsync();
            if (deleted == 0) return false;

            return true;
        }
    }
}
