using Integracao.TOTVS.Winthor.Entitys.Entitys;
namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;

public interface IContasPagarRepository
{
    Task<int> EditarFornecedorFrete(int recNum, int codFornec);

    Task<IEnumerable<ContasPagar>> BuscarContasPagarPorRecNumAsync(int recNum);
}