using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atendimentoEmpresaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Protocolocontroller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Protocolocontroller(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Protocolo>> Get()
        {
            try
            {
                var protocolo = _context.Protocolos.ToList();

                if (protocolo == null || protocolo.Count == 0)
                {
                    return NotFound("Pessoas Jurídicas Não Encontradas");
                }

                return protocolo;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Protocolo> Get(int id)
        {
            try
            {
                var protocolo = _context.Protocolos.AsNoTracking().FirstOrDefault(
                    p => p.ProtocoloID == id
                );

                if (protocolo == null)
                {
                    return NotFound("Pessoa Jurídica não encontrada.");
                }

                return protocolo;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Protocolo protocolo)
        {
            try
            {
                if (protocolo == null)
                {
                    return BadRequest("Protocolo inválido.");
                }

            
                var pessoaFisica = _context.PessoasFisicas.FirstOrDefault(
                    pf => pf.PessoaFisicaID == protocolo.PessoaFisicaID
                );

                var pessoaJuridica = _context.PessoasJuridicas.FirstOrDefault(
                    pj => pj.PessoaJuridicaID == protocolo.PessoaJuridicaID
                );

                // Verifique CPF ou CNPJ
                string cnpjCpf = "";
                if (pessoaFisica != null)
                {
                    cnpjCpf = pessoaFisica.Cpf;
                }
                else if (pessoaJuridica != null)
                {
                    cnpjCpf = pessoaJuridica.Cnpj;
                }

                // Obtenha a data 
                DateTime dataProtocolo = protocolo.DataHora;

                // Formate a data 
                string dataFormatada = dataProtocolo.ToString("yyyyMMdd");

                // Crie o código do protocolo com a data, CPF ou CNPJ
                protocolo.Codigo = dataFormatada + "-" + cnpjCpf;

                _context.Protocolos.Add(protocolo);
                _context.SaveChanges();

                return CreatedAtAction("Get", new { id = protocolo.ProtocoloID }, protocolo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var protocolo = _context.Protocolos.FirstOrDefault(
                    p => p.ProtocoloID == id
                );

                if (protocolo == null)
                {
                    return NotFound("Protocolo não encontrado.");
                }

                _context.Protocolos.Remove(protocolo);
                _context.SaveChanges();

                return Ok("Protocolo excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }
    }
}
