using backendnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backendnet.Data.Seed;

public static class SeedIdentityUserData
{
    public static void SeedUserIdentityData(this ModelBuilder modelBuilder){
    //Agregar el rol "Administrador" a la tabla AspNetRoles
    string AdministradorRoleId = Guid.NewGuid().ToString();
    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = AdministradorRoleId,
            Name = "Administrador",
            NormalizedName = "Administrador".ToUpper()
        });

        //Agregar el rol "Usuario" a la tabla AspNetRoles
        string UsuarioRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = UsuarioRoleId,
            Name = "Usuario",
            NormalizedName = "Usuario".ToUpper()
        });

        //Agregamos un usuario a la tabla AspNetUsers
        var UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
        {
            Id = UsuarioId, //primary key
            UserName = "zs20018205@estudiantes.uv.mx",
            Email = "zs20018205@estudiantes.uv.mx",
            NormalizedEmail = "zs20018205@estudiantes.uv.mx".ToUpper(),
            Nombre = "Maricarmen Vázquez Vidal",
            NormalizedUserName = "zs20018205@estudiantes.uv.mx".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null, "patito"),
            Protegido = true //este no se puede eliminar
        }
        );

        //Aplicamos la relación entre el usuario y el rol en la tabla AspNetUserRoles
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
        {
            RoleId = AdministradorRoleId,
            UserId = UsuarioId
        }
        );

        //Agregamos un usuario a la tabla AspNetUsers
        UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
        {
            Id = UsuarioId, //primary key
            UserName = "patito@uv.mx",
            Email = "patito@uv.mx",
            NormalizedEmail = "patito@uv.mx".ToUpper(),
            Nombre = "Usuario Patito",
            NormalizedUserName = "patito@uv.mx".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito"),
        }
        );

        //Aplicamos la relación entre el usuario y el rol en la tabla AspNetUserRoles
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
        {
            RoleId = UsuarioRoleId,
            UserId = UsuarioId
        }
        );

        // Agregamos el tercer usuario
        //Agregamos un usuario a la tabla AspNetUsers
    UsuarioId = Guid.NewGuid().ToString(); // Asigna un nuevo valor a UsuarioId
    modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
        {
            Id = UsuarioId, //primary key
            UserName = "usuario3@uv.mx",
            Email = "usuario3@uv.mx",
            NormalizedEmail = "usuario3@uv.mx".ToUpper(),
            Nombre = "Usuario 3",
            NormalizedUserName = "usuario3@uv.mx".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito"),
        }
    );

        //Aplicamos la relación entre el usuario y el rol en la tabla AspNetUserRoles
    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string>
        {
            RoleId = UsuarioRoleId,
            UserId = UsuarioId
        }
    );
    }
}
      
