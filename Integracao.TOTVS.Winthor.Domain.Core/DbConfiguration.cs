namespace Integracao.TOTVS.Winthor.Domain.Core;

public class DbConfiguration
{
    public string key { get; set; }
    public string ConnectionString { get; set; } 
    public Provider Provide { get; set; }

    public enum Provider
    {
        Oracle,
        SqlServer
    }
}