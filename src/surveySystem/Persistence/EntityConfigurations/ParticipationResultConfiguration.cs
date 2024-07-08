using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ParticipationResultConfiguration : IEntityTypeConfiguration<ParticipationResult>
{
    public void Configure(EntityTypeBuilder<ParticipationResult> builder)
    {
        builder.ToTable("ParticipationResults").HasKey(pr => pr.Id);

        builder.Property(pr => pr.Id).HasColumnName("Id").IsRequired();
        builder.Property(pr => pr.Result).HasColumnName("Result");
        builder.Property(pr => pr.SurveyId).HasColumnName("SurveyId");
        builder.Property(pr => pr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pr => pr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pr => pr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pr => !pr.DeletedDate.HasValue);
    }
}