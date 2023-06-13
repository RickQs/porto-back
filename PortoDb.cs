using Microsoft.EntityFrameworkCore;

namespace porto_back
{
    public class PortoDb : DbContext
    {
        public PortoDb(DbContextOptions<PortoDb> options)
            : base(options) { }

        public DbSet<Conteiner> Conteineres => Set<Conteiner>();
        public DbSet<Movimentacao> Movimentacoes => Set<Movimentacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conteiner>()
                .HasMany<Movimentacao>(c => c.Movimentacoes)
                .WithOne(m => m.Conteiner)
                .HasForeignKey(c => c.NumConteiner);

            modelBuilder.Entity<Conteiner>()
                .HasKey(c => c.NumConteiner);

            modelBuilder.Entity<Conteiner>()
                .Property(p => p.Cliente)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Conteiner>()
                .Property(p => p.TipoConteiner)
                .IsRequired();

            modelBuilder.Entity<Conteiner>()
                .Property(p => p.Status)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.Entity<Conteiner>()
                .Property(p => p.Categoria)
                .HasConversion<string>()
                .IsRequired();


            modelBuilder.Entity<Movimentacao>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Movimentacao>()
                .Property(p => p.TipoMovimentacao)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder.Entity<Movimentacao>()
                .Property(p => p.DataHoraInicio)
                .IsRequired();

            modelBuilder.Entity<Movimentacao>()
                .Property(p => p.DataHoraFim)
                .IsRequired();
        }
    }
}
