using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DemoMicroService.ServiceOne.EntityFrameworkCore;

public static class ServiceOneDbContextModelCreatingExtensions
{
    public static void ConfigureServiceOne(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<testEntity>(b =>
        {
            //Configure table & schema name
            b.ToTable(ServiceOneDbProperties.DbTablePrefix + "tetsEntities", ServiceOneDbProperties.DbSchema);

            b.ConfigureByConvention();
        });
        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(ServiceOneDbProperties.DbTablePrefix + "Questions", ServiceOneDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
