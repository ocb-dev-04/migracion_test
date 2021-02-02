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
    public class EstadosRep : IEstadosRep
    {
        private readonly AppDbContext _context;
        public EstadosRep(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Estado>> GetAll()
            => await _context.Estado.ToListAsync();

        public async Task<Estado> GetById(int id)
            => await _context.Estado.FirstOrDefaultAsync(f => f.Id == id);
        public async Task<Estado> GetByName(string name)
            => await _context.Estado.FirstOrDefaultAsync(f => f.EstadoActual == name);

        public async Task<bool> Create(Estado create)
        {
            var add = await _context.Estado.AddAsync(create);
            if (add == null) return false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Estado create)
        {
            _context.Entry(create).State = EntityState.Modified;
            var saved = await _context.SaveChangesAsync();
            if (saved == 0) return false;

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var Estado = await _context.Estado.FindAsync(id);
            if (Estado == null) return false;

            _context.Estado.Remove(Estado);
            var deleted = await _context.SaveChangesAsync();
            if (deleted == 0) return false;

            return true;
        }

    }
}
