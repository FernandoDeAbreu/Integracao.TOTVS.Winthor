namespace Integracao.TOTVS.Winthor.Domain.Services.Interfaces;

public interface IFornecedorService
{
    Task<IEnumerable<Fornecedor>> ObterFornecedorAsync(int id);

    Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresAsync();
}
