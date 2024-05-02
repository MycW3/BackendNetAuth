using backendnet.Data.Seed;
using backendnet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Data;

 public class IdentityContext : IdentityDbContext<CustomIdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
    }
    public DbSet<Pelicula> Pelicula { get; set; }
    public DbSet<Categoria> Categoria { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //inicializa la base de datos
        modelBuilder.ApplyConfiguration(new SeedCategoria());
        modelBuilder.ApplyConfiguration(new SeedPelicula());
        modelBuilder.SeedUserIdentityData();

        base.OnModelCreating(modelBuilder);
    }   
}