using Integracao.TOTVS.Winthor.Domain.Core;
using Microsoft.Data.SqlClient;
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

    public DatabaseProviderFactory(DbConfiguration configuracao)
    {
        this.configuracao = configuracao;
    }

    public IDbConnection CriarDatabaseConnection()
    {
        configuracao.ConnectionString = Environment.GetEnvironmentVariable("OracleConnectionString", EnvironmentVariableTarget.Machine) ?? string.Empty ;

        if (configuracao.Provider == DbConfiguration.ProviderEnum.Oracle)
            return new OracleConnection(configuracao.ConnectionString);

        if (configuracao.Provider == DbConfiguration.ProviderEnum.SqlServer)
            return new SqlConnection(configuracao.ConnectionString);

        throw new NotImplementedException($"Provider({configuracao.Provider}) não implementado.");
    }
}