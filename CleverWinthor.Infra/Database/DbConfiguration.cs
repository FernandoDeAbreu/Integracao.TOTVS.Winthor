namespace Integracao.TOTVS.Winthor.Infra.Database;

public class DbConfiguration
{
    public string Key { get; set; }
    public string ConnectionString { get; set; } = null!;
    public ProviderEnum Provider { get; set; }

    public enum ProviderEnum
    {
        Oracle,
        SqlServer
    }
}