namespace Integracao.TOTVS.Winthor.Domain;

public class ResumoVenda
{
    public int Ano { get; set; }
    public int Mes { get; set; }
    public decimal FatAnual { get; set; }
    public decimal VariacaoAnual { get; set; }
    public decimal FatMensal { get; set; }
    public decimal VariacaoMensal { get; set; }
    public decimal FatHoje { get; set; }
    public decimal VariacaoHoje { get; set; }
}