using Dapper;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Integracao.TOTVS.Winthor.Infra.Database;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Integracao.TOTVS.Winthor.Health;

public class DatabaseHeakthCheck : IHealthCheck
{
    private readonly IDatabaseProviderFactory _databaseProviderFactory;

    public DatabaseHeakthCheck(IDatabaseProviderFactory databaseProviderFactory)
    {
        _databaseProviderFactory = databaseProviderFactory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var connection = _databaseProviderFactory.CriarDatabaseConnection();
            connection.Open();
            string sqlQuery = @"SELECT 1";

            var result = await connection.QueryAsync<VendasPorVendedor>(sqlQuery);

            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(exception: ex);
            throw;
        }
    }
}