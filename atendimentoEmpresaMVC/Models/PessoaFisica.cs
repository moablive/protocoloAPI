using System.ComponentModel.DataAnnotations;

namespace Models;

    public class PessoaFisica
    {
        [Key]
        public int PessoaFisicaID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string? SobreNome { get; set; }

        [Required]
        [StringLength(255)]
        public string? Email { get; set; }

        [Required]
        [StringLength(255)]
        public string? Cpf { get; set; }

        [Required]
        [StringLength(255)]
        public string? Telefone { get; set; }

        [Required]
        public DateTime DatadeNasc { get; set; }

        //Relacionamento
        public int? EnderecoID { get; set; }

    }
