namespace Integracao.TOTVS.Winthor.Domain.Core;

public class HisConfiguracao
{
    public string key { get; set; }
    public string ConnectionString { get; set; } = "User Id=TENDTUDO;Password=TE26TU1122DO;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 186.193.186.249)(PORT = 3380)) ) (CONNECT_DATA = (SID = WINT) ) )";
    public ProviderEnum Provider { get; set; }

    public enum ProviderEnum
    {
        Oracle,
        SqlServer
    }
}