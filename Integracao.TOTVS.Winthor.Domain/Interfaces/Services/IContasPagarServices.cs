using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Services;

public interface IContasPagarServices
{
    Task<ContasPagar> EditarFornecedorFrete(int recNum, int codFornec);
}