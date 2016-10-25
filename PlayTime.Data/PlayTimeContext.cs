namespace PlayTime.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using PlayTime.Data.Models;

    public class PlayTimeContext : DbContext
    {
        public PlayTimeContext() : base("PlayTimeContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<User> UserSet { get; set; }
        public DbSet<Registration> RegistrationSet { get; set; }
        public DbSet<Customer> CustomerSet { get; set; }
        public DbSet<Project> ProjectSet { get; set; }
        public DbSet<Task> TaskSet { get; set; }
        public DbSet<TaskStatus> TaskStatusSet { get; set; }
        public DbSet<Preset> PresetSet { get; set; }
        public DbSet<Invoice> InvoiceSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ConfigureUserTable(modelBuilder);
            ConfigureProjectTable(modelBuilder);
            ConfigureInvoiceTable(modelBuilder);
            ConfigureTaskTable(modelBuilder);
            ConfigureTaskStatusTable(modelBuilder);
            ConfigurePresetTable(modelBuilder);
        }

        private static void ConfigureTaskTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                        .HasOptional(x => x.User);

            modelBuilder.Entity<Task>()
                        .HasOptional(x => x.TaskStatus)
                        .WithOptionalPrincipal()
                        .WillCascadeOnDelete(false);
        }

        private static void ConfigureTaskStatusTable(DbModelBuilder modelBuilder)
        {
        }

        private static void ConfigureUserTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(x => x.AssignedProjects)
                        .WithMany(x => x.AssignedUsers)
                        .Map(x =>
                        {
                            x.MapLeftKey("AssignedProjects");
                            x.MapRightKey("AssignedUsers");
                            x.ToTable("ProjectAssignedUsers");
                        });
        }

        private static void ConfigureProjectTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                        .HasMany(x => x.AssignedUsers)
                        .WithMany(x => x.AssignedProjects);
        }

        private static void ConfigureInvoiceTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                        .HasRequired(invoice => invoice.Customer)
                        .WithOptional()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                        .HasRequired(invoice => invoice.Project)
                        .WithOptional()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                        .HasMany(invoice => invoice.Tasks)
                        .WithOptional()
                        .WillCascadeOnDelete(false);
        }

        private static void ConfigurePresetTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Preset>()
                        .HasRequired(preset => preset.User)
                        .WithOptional()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Preset>()
                        .HasRequired(preset => preset.Customer)
                        .WithOptional()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Preset>()
                        .HasRequired(preset => preset.Project)
                        .WithOptional()
                        .WillCascadeOnDelete(false);
        }
    }
}