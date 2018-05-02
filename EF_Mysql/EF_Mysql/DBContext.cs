using System.Data.Entity;

namespace MySqlEntityFramework
{
    public class DBContext : DbContext
    {
        public DBContext() : base("MySqlConnection")
        {
        }

        public DbSet<Produto> Produtos { get; set; }

      
    }
}