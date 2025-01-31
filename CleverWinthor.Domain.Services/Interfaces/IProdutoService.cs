namespace Integracao.TOTVS.Winthor.Domain.Services.Interfaces;

public interface IProdutoService
{
    Task<Produto> ObterProdutoAsync(int id);

    Task<IEnumerable<Produto>> ObterProdutoByFilterAsync(int FornecedorId);
}