using Dapper;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Integracao.TOTVS.Winthor.Infra.Database;

namespace Integracao.TOTVS.Winthor.Infra.Repositorys
{
    public class ContasPagarRepository : IContasPagarRepository
    {
        private readonly IDatabaseProviderFactory _databaseProviderFactory;

        public ContasPagarRepository(IDatabaseProviderFactory databaseProviderFactory)
        {
            _databaseProviderFactory = databaseProviderFactory;
        }

        public async Task<IEnumerable<ContasPagar>> BuscarContasPagarPorRecNumAsync(int recNum)
        {
            using (var connection = _databaseProviderFactory.CriarDatabaseConnection())
            {
                connection.Open();

                var parameters = new { recNum };
                var query = "SELECT C.RECNUM, C.HISTORICO, C.DTVENC, C.VALOR, C.CODFORNEC " +
                                "FROM PCLANC C WHERE C.CODROTINACAD LIKE '%PCSIS1301%' AND C.RECNUM = :RECNUM";

                return await connection.QueryAsync<ContasPagar>(query, parameters);
            }
        }

        public async Task<int> EditarFornecedorFrete(int recNum, int codFornec)
        {
            using (var connection = _databaseProviderFactory.CriarDatabaseConnection())
            {
                connection.Open();

                var parameters = new { CODFORNEC = codFornec, RECNUM = recNum };
                var query = "UPDATE PCLANC C SET  C.CODFORNEC = :CODFORNEC WHERE C.RECNUM = :RECNUM ";

                var r = await connection.ExecuteAsync(query, parameters);
                return r;
            }
        }
    }
}