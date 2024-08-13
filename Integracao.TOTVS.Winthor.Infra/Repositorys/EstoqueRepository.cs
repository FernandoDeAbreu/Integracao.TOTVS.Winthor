using Dapper;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Integracao.TOTVS.Winthor.Infra.Database;

namespace Integracao.TOTVS.Winthor.Infra.Repositorys
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly IDatabaseProviderFactory _databaseProviderFactory;

        public EstoqueRepository(IDatabaseProviderFactory databaseProviderFactory)
        {
            _databaseProviderFactory = databaseProviderFactory;
        }

        public async Task<IEnumerable<PcEst>> BuscarEstoqueAsync(string codprod)
        {
            using var connection = _databaseProviderFactory.CriarDatabaseConnection();
            connection.Open();

            var parameters = new { codprod };
            var query = "SELECT * FROM PCEST WHERE CODFILIAL = :codprod";

            return await connection.QueryAsync<PcEst>(query, parameters);
        }
    }
}