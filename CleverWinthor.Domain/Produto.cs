namespace Integracao.TOTVS.Winthor.Domain;

public class Produto
{
    public int CodProd { get; set; }
    public string? Descricao { get; set; }
    public string? CodFab { get; set; }
    public string? CodAuxiliar { get; set; }
    public int CodFornec { get; set; }
    public string? Fornecedor { get; set; }
    public string? CodNcmEx { get; set; }
    public string? Ncm { get; set; }
    public int CodEpto { get; set; }
    public string? Departamento { get; set; }
    public int CodSec { get; set; }
    public string? Secao { get; set; }
    public decimal CustoUltEnt { get; set; }
    public decimal CustoCont { get; set; }
    public decimal CustoReal { get; set; }
    public decimal CustoUltEntFin { get; set; }
    public decimal CustoFin { get; set; }
    public decimal Pvenda { get; set; }
    public decimal Ptabela { get; set; }
    public int QtestGer { get; set; }
}