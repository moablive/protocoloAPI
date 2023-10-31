using System.ComponentModel.DataAnnotations;

namespace Models;

    public class Endereco
    {
        [Key]
        public int EnderecoID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Pais { get; set; }

        [Required]
        [StringLength(255)]
        public string? Estado { get; set; }

        [Required]
        [StringLength(255)]
        public string? Cidade { get; set; }

        [Required]
        [StringLength(255)]
        public string? Bairro { get; set; }

        [Required]
        [StringLength(255)]
        public string? Rua { get; set; }

        [Required]
        [StringLength(255)]
        public string? Numero { get; set; }

        [Required]
        [StringLength(255)]
        public string? Cep { get; set; }

    }
