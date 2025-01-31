using Microsoft.EntityFrameworkCore;

namespace Integracao.TOTVS.Winthor.Infra.Database;

public class CleverDbContext : DbContext
{
    public CleverDbContext(DbContextOptions<CleverDbContext> options) : base(options)
    {
    }
}