using ControleTarefas.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.ToTable("tarefas", "public");

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Id)
                  .HasColumnName("id");

            entity.Property(t => t.Titulo)
                  .HasColumnName("titulo")
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(t => t.Descricao)
                  .HasColumnName("descricao")
                  .IsRequired();

            entity.Property(t => t.Prioridade)
                  .HasColumnName("prioridade")
                  .IsRequired();

            entity.Property(t => t.Status)
                  .HasColumnName("status")
                  .IsRequired();

            entity.Property(t => t.DataCriacao)
                  .HasColumnName("data_criacao")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
