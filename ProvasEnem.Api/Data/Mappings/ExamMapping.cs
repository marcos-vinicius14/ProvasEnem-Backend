using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvasEnem.Core.Models;

namespace ProvasEnem.Api.Data.Mappings;

public class ExamMapping : IEntityTypeConfiguration<ExamModel>
{
    public void Configure(EntityTypeBuilder<ExamModel> builder)
    {
        builder.ToTable("Exams");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ColorNotebook)
            .IsRequired(true)
            .HasColumnName("Color Notebook")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.ExamDate)
            .IsRequired(true)
            .HasColumnName("Exam Date")
            .HasColumnType("DATETIME2")
            .HasMaxLength(20);

        builder.Property(x => x.ContentPdf)
            .IsRequired(true)
            .HasColumnName("PDF")
            .HasColumnType("IMAGE");
    }
}