using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimplePublishingPlatform.Models;

namespace SimplePublishingPlatform.DAL
{
    public class PublishingPlatformContext:DbContext
    {
        public DbSet<SoftwareVersion> Versions { get; set; }
        public DbSet<ProblemInfo> ProblemInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}