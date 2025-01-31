using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Integracao.TOTVS.Winthor.Infra.Interfaces;

namespace Integracao.TOTVS.Winthor.Domain.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _forncedorRepository;

    public FornecedorService(IFornecedorRepository forncedorRepository)
    {
        _forncedorRepository = forncedorRepository;
    }

    public async Task<IEnumerable<Fornecedor>> ObterFornecedorAsync(int id)
    {
        return await _forncedorRepository.ObterFornecedorAsync(id);
    }

    public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresAsync()
    {
        return await _forncedorRepository.ObterTodosFornecedoresAsync();
    }
}