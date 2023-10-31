using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Context;

namespace atendimentoEmpresaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoaFisicaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PessoaFisica>> Get()
        {
            try
            {
                var pessoaFisica = _context.PessoasFisicas.AsNoTracking().ToList();

                if (pessoaFisica == null || pessoaFisica.Count == 0)
                {
                    return NotFound("Pessoas Físicas Não Encontradas");
                }

                return pessoaFisica;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<PessoaFisica> Get(int id)
        {
            try
            {
                var pessoaFisica = _context.PessoasFisicas.AsNoTracking().FirstOrDefault(
                    pf => pf.PessoaFisicaID == id
                );

                if (pessoaFisica == null)
                {
                    return NotFound("Pessoa Física não encontrada.");
                }

                return pessoaFisica;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PessoaFisica pessoaFisica)
        {
            try
            {
                if (pessoaFisica == null)
                {
                    return BadRequest("Pessoa Física inválida.");
                }
                
                _context.PessoasFisicas.Add(pessoaFisica);
                _context.SaveChanges();

                return CreatedAtAction("Get", new { id = pessoaFisica.PessoaFisicaID }, pessoaFisica);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] PessoaFisica pessoaFisica)
        {
            try
            {
                if (id != pessoaFisica.PessoaFisicaID)
                {
                    return BadRequest("ID da Pessoa Física não corresponde ao ID na requisição.");
                }

                _context.Entry(pessoaFisica).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok("Pessoa Física atualizada com sucesso.");
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
                var pessoaFisica = _context.PessoasFisicas.FirstOrDefault(
                    pf => pf.PessoaFisicaID == id
                );

                if (pessoaFisica == null)
                {
                    return NotFound("Pessoa Física não encontrada.");
                }

                _context.PessoasFisicas.Remove(pessoaFisica);
                _context.SaveChanges();

                return Ok("Pessoa Física excluída com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }
    }
}
