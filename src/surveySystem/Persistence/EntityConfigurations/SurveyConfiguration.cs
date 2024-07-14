using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nest;

namespace Persistence.EntityConfigurations;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Title).HasColumnName("Title");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        builder.HasData(_seeds);
    }

    public IEnumerable<Survey> _seeds
    {
        get
        {
            var questions = new List<Survey>();
            for (int i = 0; i < 5; i++)
            {
                questions.Add(new Survey()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Title = $"Örnek Anket : Enocta Kurum Anketi {i++}"
                });
            }
            return questions;
        }
    }
}