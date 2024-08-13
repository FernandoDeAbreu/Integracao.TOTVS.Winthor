namespace Integracao.TOTVS.Winthor.Domain.Core;

public class DbConfiguration
{
    public string key { get; set; }
    public string ConnectionString { get; set; } 
    public ProviderEnum Provider { get; set; }

    public enum ProviderEnum
    {
        Oracle,
        SqlServer
    }
}