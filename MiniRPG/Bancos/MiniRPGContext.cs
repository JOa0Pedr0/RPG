using Microsoft.EntityFrameworkCore;
using MiniRPG.ModelosPrincipais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRPG.Bancos;

internal class MiniRPGContext : DbContext
{
    public DbSet<Player> Players { get; set; }
   private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MiniRPGV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer(connectionString);
    }
}
