using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Context;

namespace atendimentoEmpresaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoaJuridicaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PessoaJuridica>> Get()
        {
            try
            {
                var pessoaJuridica = _context.PessoasJuridicas.AsNoTracking().ToList();

                if (pessoaJuridica == null || pessoaJuridica.Count == 0)
                {
                    return NotFound("Pessoas Jurídicas Não Encontradas");
                }

                return pessoaJuridica;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<PessoaJuridica> Get(int id)
        {
            try
            {
                var pessoaJuridica = _context.PessoasJuridicas.AsNoTracking().FirstOrDefault(
                    pj => pj.PessoaJuridicaID == id
                );

                if (pessoaJuridica == null)
                {
                    return NotFound("Pessoa Jurídica não encontrada.");
                }

                return pessoaJuridica;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (pessoaJuridica == null)
                {
                    return BadRequest("Pessoa Jurídica inválida.");
                }

                _context.PessoasJuridicas.Add(pessoaJuridica);
                _context.SaveChanges();

                return CreatedAtAction("Get", new { id = pessoaJuridica.PessoaJuridicaID }, pessoaJuridica);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (id != pessoaJuridica.PessoaJuridicaID)
                {
                    return BadRequest("ID da Pessoa Jurídica não corresponde ao ID na requisição.");
                }

                _context.Entry(pessoaJuridica).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok("Pessoa Jurídica atualizada com sucesso.");
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
                var pessoaJuridica = _context.PessoasJuridicas.FirstOrDefault(
                    pj => pj.PessoaJuridicaID == id
                );

                if (pessoaJuridica == null)
                {
                    return NotFound("Pessoa Jurídica não encontrada.");
                }

                _context.PessoasJuridicas.Remove(pessoaJuridica);
                _context.SaveChanges();

                return Ok("Pessoa Jurídica excluída com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }
    }
}
