using Empresa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Empresa.Contexts;

public class EmpresaContext : DbContext
{
    public EmpresaContext()
    {

    }

    public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost; Database=Empresa; User Id=sa; Password=ADMIN@admin; Trusted_Connection=false; MultipleActiveResultSets=true;");
        }
    }

    public DbSet<Projeto>? Projeto { get; set; }
}