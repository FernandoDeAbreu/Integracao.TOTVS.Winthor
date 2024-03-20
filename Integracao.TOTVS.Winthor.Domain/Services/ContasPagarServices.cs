using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Services;
using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Services
{
    public class ContasPagarServices : IContasPagarServices
    {
        private readonly IContasPagarRepository _contasPagarRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public ContasPagarServices(IContasPagarRepository contasPagarRepository, IFornecedorRepository fornecedorRepository)
        {
            _contasPagarRepository = contasPagarRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<ContasPagar> EditarFornecedorFrete(int recNum, int CodFornec)
        {
            if (recNum == null)
                return null;

            var fornecedor = _fornecedorRepository.BuscarFornecedorPorCodFornecAsync(CodFornec);
            if (!fornecedor.Result.Any())
                return null;

            var contasPagar = _contasPagarRepository.BuscarContasPagarPorRecNumAsync(recNum);
            if (!contasPagar.Result.Any())
                return null;

            await _contasPagarRepository.EditarFornecedorFrete(CodFornec, recNum);

            return new ContasPagar { };
        }
    }
}