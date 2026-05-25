using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCoreGeneratedDocument;
using Microsoft.Identity.Client;

namespace bibliotec.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataReserva { get; set; }

        public DateTime? DataEmprestimo { get; set; }

        public DateTime? DataPrevistaDevolucao { get; set; }

        public string? DanoLivro { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; } = null!;
        // E = espera; P = posse; A = atrasado; F = finalizada;

        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Usuario Aluno { get; set; } = null!;

        public int LivroId { get ; set; }

        [ForeignKey("LivroId")]
        public Livro Livro { get; set; } = null!;
    }
}