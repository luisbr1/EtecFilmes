using System;
using System.Collections.Generic;
using EtecFilmes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EtecFilmes.Data
{
    public class Contexto : IdentityDbContext<User>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Entity Settings
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });
            #endregion

            #region Populate Roles
            //IDS DOS USUARIOS
            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODERADOR_ID = Guid.NewGuid().ToString();
            string USUARIO_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole{
                Id = ADMIN_ID,
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole
            {
                Id = MODERADOR_ID,
                Name = "Moderador",
                NormalizedName = "MODERADOR"
            },
            new IdentityRole
            {
                Id = USUARIO_ID,
                Name = "Usuario",
                NormalizedName = "USUARIO"
            });

            #endregion

            #region Populate Admin

            var hash1= new PasswordHasher<User>();
            byte[] avatarPic = System.IO.File.ReadAllBytes(
                System.IO.Directory.GetCurrentDirectory()+ @"\wwwroot\img\avatar.png"
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = ADMIN_ID,
                    Name = "Luis Fernando Paes",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@etecfilmes.com.br",
                    NormalizedEmail = "ADMIN@ETECFILMES.COM.BR",
                    EmailConfirmed = true,
                    PasswordHash = hash1.HashPassword(null, "123456"),
                    SecurityStamp = hash1.GetHashCode().ToString(),
                    ProfilePicture = avatarPic
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ID,
                    UserId = ADMIN_ID
                }
            );
                
            #endregion
        }
    }
}