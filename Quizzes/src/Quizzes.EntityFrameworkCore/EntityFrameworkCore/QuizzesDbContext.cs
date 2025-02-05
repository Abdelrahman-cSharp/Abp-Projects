using Microsoft.EntityFrameworkCore;
using Quizzes.Questions;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Quizzes.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class QuizzesDbContext :
    AbpDbContext<QuizzesDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<MCQ> MCQQuestions { get; set; }
    public DbSet<TF> TFQuestions { get; set; }

    #endregion

    public QuizzesDbContext(DbContextOptions<QuizzesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(QuizzesConsts.DbTablePrefix + "YourEntities", QuizzesConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Quiz>(b =>
        {
            b.ToTable("Quizzes");
            b.ConfigureByConvention();

            b.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            b.HasMany(x => x.MCQs)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId)
                .IsRequired();

            b.HasMany(x => x.TFs)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId)
                .IsRequired();

            b.Property(x => x.TimeLimitMin)
                .IsRequired();

            b.Property(x => x.AttemptsLimit)
                .HasDefaultValue(1);

        });


        builder.Entity<MCQ>(b =>
        {
            b.ToTable("MCQQuestions");
            b.ConfigureByConvention();

            b.Property(x => x.Title)
                .HasMaxLength(512)
                .IsRequired();

            b.Property(x => x.Choice1)
                .HasMaxLength(512)
                .IsRequired();

            b.Property(x => x.Choice2)
                .HasMaxLength(512)
                .IsRequired();

            b.Property(x => x.Choice3)
                .HasMaxLength(512)
                .IsRequired();

            b.Property(x => x.Choice4)
                .HasMaxLength(512)
                .IsRequired();

            b.Property(x => x.CorrectAnswer)
                .HasMaxLength(512)
                .IsRequired();

            b.Property(x => x.SelectedAnswer)
                .HasMaxLength(512)
                .HasDefaultValue(null);

            b.HasOne(x => x.Quiz)
                .WithMany(x => x.MCQs)
                .HasForeignKey(x => x.QuizId)
                .IsRequired();
        });


        builder.Entity<TF>(b =>
        {
            b.ToTable("TFQuestions");
            b.ConfigureByConvention();

            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(512);

            b.Property(x => x.CorrectAnswer)
                .IsRequired();

            b.Property(x => x.SelectedAnswer)
                .HasDefaultValue(null);

            b.HasOne(x => x.Quiz)
                .WithMany(x => x.TFs)
                .HasForeignKey(x => x.QuizId)
                .IsRequired();
        });




    }
}
