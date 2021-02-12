using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IaraAPI.Data;
using IaraAPI.Models;
using System.Web;
using IaraAPI.Libraries;
using RestSharp;
using RestSharp.Serialization.Json;

namespace IaraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacoesController : ControllerBase
    {
        private readonly IaraAPIContext _context;

        public CotacoesController(IaraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Cotacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotacao>>> GetCotacao()
        {
            return await _context.Cotacao.Include(a => a.CotacaoItens).ToListAsync();
        }

        // GET: api/Cotacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotacao>> GetCotacao(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);

            if (cotacao == null)
            {
                return NotFound();
            }

            return cotacao;
        }

        // PUT: api/Cotacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotacao(int id, Cotacao cotacao)
        {
            if (id != cotacao.CotacaoId)
            {
                return BadRequest();
            }

            _context.Entry(cotacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cotacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cotacao>> PostCotacao(Cotacao cotacao)
        {
            if (!String.IsNullOrEmpty(cotacao.CEP))
            {
                DadosRetorno dadosRetorno = Utils.GetViaCEP(cotacao.CEP);

                if (dadosRetorno != null) 
                { 
                    if(String.IsNullOrEmpty(cotacao.Logradouro))
                        cotacao.Logradouro = dadosRetorno.logradouro;
                    if (String.IsNullOrEmpty(cotacao.UF))
                        cotacao.UF = dadosRetorno.uf;
                    if (String.IsNullOrEmpty(cotacao.Bairro))
                        cotacao.Bairro = dadosRetorno.bairro;
                }
            }
            _context.Cotacao.Add(cotacao);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotacao", new { id = cotacao.CotacaoId }, cotacao);
        }

        // DELETE: api/Cotacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotacao(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);
            if (cotacao == null)
            {
                return NotFound();
            }

            _context.Cotacao.Remove(cotacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CotacaoExists(int id)
        {
            return _context.Cotacao.Any(e => e.CotacaoId == id);
        }
    }
}
