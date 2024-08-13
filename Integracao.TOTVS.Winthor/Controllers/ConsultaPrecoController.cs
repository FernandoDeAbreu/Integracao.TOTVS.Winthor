using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.TOTVS.Winthor.Controllers
{
    [Route("api/consulta-preco")]
    [ApiController]
    public class ConsultaPrecoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ConsultaPreco>> VendasPorVendedor(string codprod)
        {
            var preco = new ConsultaPreco()
            {
                CodProd = "152525",
                Preco = "7,50",
                CodBarras = "7895463251241",
                CodFab = "CD-3514",
                Descricao = "CELULAR ANDROID SAMSUNG SM-1245",
                Estoque = "10,00"

            };

            try
            {
                var response = preco;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}