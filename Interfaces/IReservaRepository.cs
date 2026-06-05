using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Models;

namespace bibliotec.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> BuscarReservasComDetalhes();

        Task<IEnumerable<Reserva>> BuscarReservasPorUsuarioId(int usuarioId);
    }
}