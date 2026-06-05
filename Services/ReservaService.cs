using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Interfaces;
using bibliotec.Models;

namespace bibliotec.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Reserva>> BuscarReservasAsync()
        {
            return await _repository.BuscarReservasComDetalhes();
        }

        public async Task<IEnumerable<Reserva>> BuscarReservasPorUsuarioAsync(int usuarioId)
        {
            return await _repository.BuscarReservasPorUsuarioId(usuarioId);
        }
    }
}