using Domain.Entities.ToDo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.ToTable("to_do");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .HasColumnType("varchar")
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Description)
                    .HasColumnType("varchar")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Status)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.DueDate)
                .IsRequired()
                .HasColumnType("datetime");


        }
    }
}
