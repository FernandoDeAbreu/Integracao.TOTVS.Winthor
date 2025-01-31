using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Integracao.TOTVS.Winthor.Infra.Database;

public interface IDatabaseProviderFactory
{
    IDbConnection CriarDatabaseConnection();
}

public sealed class DatabaseProviderFactory : IDatabaseProviderFactory
{
    private readonly DbConfiguration configuracao;
    private readonly string _connectionString;

    public DatabaseProviderFactory(DbConfiguration configuracao, IConfiguration configuration)
    {
        this.configuracao = configuracao;
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
    }

    public IDbConnection CriarDatabaseConnection()
    {
        if (configuracao.Provider == DbConfiguration.ProviderEnum.Oracle)
            return new OracleConnection(_connectionString);

        if (configuracao.Provider == DbConfiguration.ProviderEnum.SqlServer)
            return new SqlConnection(_connectionString);

        throw new NotImplementedException($"Provider({configuracao.Provider}) não implementado.");
    }
}