using BibliotecaCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaInfra.EntityFramework
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions options) : base(options) { }

        public DbSet<Livro> Livro { get; set; } 
        public DbSet<Autor> Autor { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroAutor>().HasKey(sc => new { sc.LivroId, sc.AutorId });

            modelBuilder.Entity<LivroAutor>().HasOne<Livro>(id => id.Livro).WithMany(id => id.Autores).HasForeignKey(id => id.LivroId);

            modelBuilder.Entity<LivroAutor>().HasOne<Autor>(id => id.Autor).WithMany(id => id.Livros).HasForeignKey(id => id.AutorId);
        }
    }
}
