using System.ComponentModel.DataAnnotations;

namespace Models;

    public class PessoaJuridica
    {
        [Key]
        public int PessoaJuridicaID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string? NomeFantasia { get; set; }

        [Required]
        [StringLength(255)]
        public string? Cnpj { get; set; }

        [Required]
        [StringLength(255)]
        public string? Telefone { get; set; }

        [Required]
        [StringLength(255)]
        public string? Email { get; set; }

        //Relacionamento
        public int? EnderecoID { get; set; }
    }
