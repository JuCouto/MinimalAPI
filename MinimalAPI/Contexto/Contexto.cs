
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace MinimalAPI.Contexto
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) :base(options) => Database.EnsureCreated(); //ensurecreated , na 1/ vez que executa verifica se o
                                                                                                        //banco existe se não existir ele cria o banco, mas precisa informar oq ele vai criar
        public DbSet<Produto> Produto { get; set; }
    }
}
