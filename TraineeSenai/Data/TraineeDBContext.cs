using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Models;
using SistemaDeTarefas.Data.Map;


namespace PrimeiraApi.Data
{
    //facilitador para trablhar com qualquer banco de dados
    public class TraineeDBContext : DbContext
    {
        //conexao com o bd
        public TraineeDBContext(DbContextOptions<TraineeDBContext> options)
            : base(options)
        {
        }

        //tabelas no bd
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
