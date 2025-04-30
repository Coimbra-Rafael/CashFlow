using CashFlow.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : base(options) {}
    public CashFlowDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cash_flow;Uid=rafael;Pwd=1qazzaq!;";
        var serverVersion = new MySqlServerVersion(new Version("8.0.39"));
        optionsBuilder.UseMySql(connectionString, serverVersion);

    }

}
