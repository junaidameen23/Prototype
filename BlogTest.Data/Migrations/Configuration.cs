namespace BlogTest.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DbContext;
    using Model.Entities;
    using BlogTest.Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogTest.Data.DbContext.BlogTestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogTest.Data.DbContext.BlogTestDbContext context)
        {
            //AddGenders(context);
        }

        private void AddGenders(BlogTestDbContext context)
        {
            context.Database.ExecuteSqlCommand("Set Identity_Insert Gender OFF");

            context.Gender.Add(new Gender { Id = 1, Name = "Female", IsActive = true });
            context.Gender.Add(new Gender { Id = 2, Name = "Male", IsActive = true });
            context.Gender.Add(new Gender { Id = 3, Name = "Others", IsActive = true });

            context.Database.ExecuteSqlCommand("Set Identity_Insert Gender ON");

        }
    }
}
