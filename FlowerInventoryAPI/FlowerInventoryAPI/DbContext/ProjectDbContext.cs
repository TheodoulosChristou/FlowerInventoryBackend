using FlowerInventoryAPI.Configurations;
using FlowerInventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;


    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {

        }
        

        public DbSet<Flower> Flower { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.ApplyConfiguration(new FlowerConfiguration());
             modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
}

