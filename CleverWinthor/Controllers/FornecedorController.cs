using Integracao.TOTVS.Winthor.Api.Controllers.Common;
using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.TOTVS.Winthor.Api.Controllers;

[Route("api/fornecedor")]
[ApiController]
public class FornecedorController : CleverControllerBase
{
    private readonly ILogger<FornecedorController> _logger;
    private readonly IFornecedorService _fornecedorService;

    public FornecedorController(ILogger<FornecedorController> logger, IFornecedorService fornecedorService)
    {
        _logger = logger;
        _fornecedorService = fornecedorService;
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            _logger.LogInformation("Processando a solicitação do método Get.");
            var data = await _fornecedorService.ObterFornecedorAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            _logger.LogInformation("Processando a solicitação do método Get.");
            var data = await _fornecedorService.ObterTodosFornecedoresAsync();
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }
}