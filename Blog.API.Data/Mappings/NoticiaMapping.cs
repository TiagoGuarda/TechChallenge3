using Blog.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.API.Data.Mappings
{
    public class NoticiaMapping : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Titulo)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Conteudo)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(p => p.DataPublicacao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Autor)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.ToTable("Noticia");
        }
    }
}
