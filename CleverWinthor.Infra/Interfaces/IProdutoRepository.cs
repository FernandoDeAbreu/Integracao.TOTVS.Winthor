using Integracao.TOTVS.Winthor.Domain;

namespace Integracao.TOTVS.Winthor.Infra.Interfaces;

public interface IProdutoRepository
{
    Task<Produto> ObterProdutoAsync(int CodProd);

    Task<IEnumerable<Produto>> ObterProdutoByFilterAsync(int FornecedorId);
}