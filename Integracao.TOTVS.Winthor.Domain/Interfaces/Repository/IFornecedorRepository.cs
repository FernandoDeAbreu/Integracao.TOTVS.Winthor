using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> BuscarFornecedorPorCodFornecAsync(int CodFornec);
    }
}