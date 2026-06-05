using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Contexts;
using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotec.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly BbDbContext _context;

        public ReservaRepository(BbDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reserva>> BuscarReservasComDetalhes()
        {
            return await _context.Reserva.Include(r => r.Livro).Include(r => r.Aluno).OrderBy(r => r.DataReserva).ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> BuscarReservasPorUsuarioId(int usuarioId)
        {
            return await _context.Reserva.Include(r => r.Livro).Include(r => r.Aluno).OrderBy(r => r.DataReserva).Where(r => r.AlunoId == usuarioId).ToListAsync();
        }
    }
}