namespace BlogTest.Data.DbContext
{
    using BlogTest.Model.Entities;
    using Model.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class BlogTestDbContext : System.Data.Entity.DbContext
    {
        public BlogTestDbContext()
            : base("BlogTestDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BlogTestDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Gender> Gender { get; set; }
    }
}
