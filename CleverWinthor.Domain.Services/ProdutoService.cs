using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Integracao.TOTVS.Winthor.Infra.Interfaces;

namespace Integracao.TOTVS.Winthor.Domain.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _forncedorRepository;

    public ProdutoService(IProdutoRepository forncedorRepository)
    {
        _forncedorRepository = forncedorRepository;
    }

    public async Task<Produto> ObterProdutoAsync(int id)
    {
        return await _forncedorRepository.ObterProdutoAsync(id);
    }
    public async Task<IEnumerable<Produto>> ObterProdutoByFilterAsync(int FornecedorId)
    {
        return await _forncedorRepository.ObterProdutoByFilterAsync(FornecedorId);
    }
}