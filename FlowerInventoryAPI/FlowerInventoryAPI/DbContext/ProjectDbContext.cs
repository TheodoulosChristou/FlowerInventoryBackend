using FlowerInventoryAPI.Configurations;
using FlowerInventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;


    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {

        }
        

        public DbSet<Flower> Flower { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.ApplyConfiguration(new FlowerConfiguration());
        }
}

