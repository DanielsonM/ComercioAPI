using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Comercio.Dominio.Model;

namespace Comercio.Infraestrutura.Repositorio
{
    public class DbConexao : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=sexshop;Uid=root;Pwd=root;";
            optionsBuilder.UseMySQL(connectionString);
        }


    }
}
