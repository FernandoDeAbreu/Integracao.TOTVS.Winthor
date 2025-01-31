using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Integracao.TOTVS.Winthor.Infra.Interfaces;

namespace Integracao.TOTVS.Winthor.Domain.Services;

public class ResumoVendasService : IResumoVendasService
{
    private readonly IResumoVendasRepository _resumoVendasRepository;

    public ResumoVendasService(IResumoVendasRepository resumoVendasRepository)
    {
        _resumoVendasRepository = resumoVendasRepository;
    }

    public async Task<IEnumerable<Venda>> ObterVendasPorEvolucaoAsync()
    {
        var response = await _resumoVendasRepository.ObterVendasPorEvolucaoAsync();
        var resumoVendas = new List<Venda>();

        var qtDias = DateTime.Today - Convert.ToDateTime("01/01/2014");

        var hoje = DateTime.Today;
        int ultimoDia = DateTime.DaysInMonth(hoje.Year, hoje.Month);
        var ultimoDiaDoMes = Convert.ToDateTime($"{hoje.Year}/{hoje.Month}/{ultimoDia}");

        for (int i = 0; i < qtDias.Days; i++)
        {
            var dateTime = ultimoDiaDoMes.AddDays(-i);

            if (dateTime.Month == 2)
            {
                var vendaDia = response.FirstOrDefault(c => c.Data.Date == dateTime.Date);

                vendaDia ??= new Venda { Data = dateTime, VlVenda = 0 };

                resumoVendas.Add(vendaDia);
            }
        }
        return resumoVendas;
    }

    public async Task<IEnumerable<ResumoVenda>> ObterResumoVendasAsync()
    {
        var mesParamentro = 2;
        var response = await _resumoVendasRepository.ObterVendasPorEvolucaoAsync();
        var resumoVendasList = new List<ResumoVenda>();

        for (int ano = 2014; ano <= DateTime.Today.Year; ano++)
        {
            int ultimoDia = DateTime.DaysInMonth(ano, mesParamentro);
            var ultimoDiaDoMes = Convert.ToDateTime($"{ano}/{mesParamentro}/{ultimoDia}");

            var resumoVendas = new ResumoVenda
            {
                Ano = ano,
                Mes = mesParamentro,
                FatAnual = response.Where(c => c.Data.Year == ano).Sum(c => c.VlVenda),
                FatMensal = response.Where(c => c.Data >= Convert.ToDateTime($"01/{mesParamentro}/{ano}") &&
                                                c.Data <= ultimoDiaDoMes).Sum(c => c.VlVenda)
            };

            resumoVendasList.Add(resumoVendas);
        }

        CalcularVariacao(resumoVendasList);

        return resumoVendasList;
    }

    private static void CalcularVariacao(List<ResumoVenda> resumoVendasList)
    {
        foreach (var item in resumoVendasList)
        {
            var fatAnoAnterior = resumoVendasList.FirstOrDefault(c => c.Ano == item.Ano - 1)?.FatAnual ?? 0;
            var fatAnoAtual = item.FatAnual;
            item.VariacaoAnual = fatAnoAnterior == 0 ? 0 : ((fatAnoAtual - fatAnoAnterior) / fatAnoAnterior) * 100;

            var fatMesAnterior = resumoVendasList.FirstOrDefault(c => c.Ano == item.Ano - 1 && c.Mes == item.Mes)?.FatMensal ?? 0;
            var fatMesAtual = item.FatMensal;
            item.VariacaoMensal = fatMesAnterior == 0 ? 0 : ((fatMesAtual - fatMesAnterior) / fatMesAnterior) * 100;

        }
    }
}