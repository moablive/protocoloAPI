using System.ComponentModel.DataAnnotations;

public class Protocolo
{
    [Key]
    public int ProtocoloID { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataHora { get; set; }
    public string Codigo { get; set; }
    public int PessoaFisicaID { get; set; }
    public int PessoaJuridicaID { get; set; }
}
