using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvasEnem.Core.Models;

namespace ProvasEnem.Api.Data.Mappings;

public class PostMapping : IEntityTypeConfiguration<PostModel>
{
    public void Configure(EntityTypeBuilder<PostModel> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(25);

        builder.Property(x => x.Tag)
            .IsRequired(true)
            .HasColumnName("Tags")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Content)
            .IsRequired(true)
            .HasColumnName("Contents")
            .HasColumnType("NVARCHAR");
    }
}