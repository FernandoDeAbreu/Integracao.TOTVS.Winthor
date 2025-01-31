using Integracao.TOTVS.Winthor.Domain;

namespace Integracao.TOTVS.Winthor.Infra.Interfaces;

public interface IFornecedorRepository
{
    Task<IEnumerable<Fornecedor>> ObterFornecedorAsync(int CodFornec);

    Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresAsync();
}
