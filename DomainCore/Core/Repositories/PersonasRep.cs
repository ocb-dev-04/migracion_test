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
    public class PersonasRep : IPersonasRep
    {
        private readonly AppDbContext _context;
        public PersonasRep(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Personas>> GetAll()
            => await  _context.Personas.ToListAsync();

        public async Task<Personas> GetById(int id)
            => await _context.Personas.FirstOrDefaultAsync(f => f.Id == id);

        public async Task<bool> Create(Personas create)
        {
            var add = await _context.Personas.AddAsync(create);
            if (add == null) return false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Personas create)
        {
            _context.Entry(create).State = EntityState.Modified;
            var saved = await _context.SaveChangesAsync();
            if (saved == 0) return false;

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var personas = await _context.Personas.FindAsync(id);
            if (personas == null) return false;

            _context.Personas.Remove(personas);
            var deleted = await _context.SaveChangesAsync();
            if (deleted == 0) return false;

            return true;
        }
    }
}
