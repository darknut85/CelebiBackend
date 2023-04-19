﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4f39a600-56e2-4204-80fd-d38cbf156eff",
                            ConcurrencyStamp = "aec62267-a49a-400e-b4cc-305a6f08a6f2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "7fa21ea0-f11b-4c73-a54f-3f2527fd10e8",
                            ConcurrencyStamp = "b0c191f3-d89d-462e-8e7b-63afeffab947",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "84352829-2372-4460-a0c2-65d7f4509212",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a58b460f-261e-4635-9e7c-9a90f06398ef",
                            Email = "new.user@newUser.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "NEW.USER@NEWUSER.COM",
                            NormalizedUserName = "NEWUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "110ad665-500b-4350-bade-4a63fa975edd",
                            TwoFactorEnabled = false,
                            UserName = "NewUser"
                        },
                        new
                        {
                            Id = "e2066f3e-5cff-4c63-a389-468e9ca5358f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be4d8eab-e071-49a7-9c35-765d9aa73e2f",
                            Email = "reall.admin@admin.eal",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "REALL.ADMIN@ADMIN.EAL",
                            NormalizedUserName = "REALADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3f4ea29c-fb3b-496a-b966-db95c3ff8d7a",
                            TwoFactorEnabled = false,
                            UserName = "RealAdmin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Objects.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("ATK")
                        .HasColumnType("double precision");

                    b.Property<double>("ATKEV")
                        .HasColumnType("double precision");

                    b.Property<double>("CaptureRate")
                        .HasColumnType("double precision");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("DEF")
                        .HasColumnType("double precision");

                    b.Property<double>("DEFEV")
                        .HasColumnType("double precision");

                    b.Property<int>("DexEntry")
                        .HasColumnType("integer");

                    b.Property<double>("GrowthRate")
                        .HasColumnType("double precision");

                    b.Property<double>("HP")
                        .HasColumnType("double precision");

                    b.Property<double>("HPEV")
                        .HasColumnType("double precision");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PokedexEntry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("SPATK")
                        .HasColumnType("double precision");

                    b.Property<double>("SPATKEV")
                        .HasColumnType("double precision");

                    b.Property<double>("SPD")
                        .HasColumnType("double precision");

                    b.Property<double>("SPDEF")
                        .HasColumnType("double precision");

                    b.Property<double>("SPDEFEV")
                        .HasColumnType("double precision");

                    b.Property<double>("SPDEV")
                        .HasColumnType("double precision");

                    b.Property<string>("Type1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ATK = 49.0,
                            ATKEV = 49.0,
                            CaptureRate = 45.0,
                            Classification = "Seed Pokemon",
                            DEF = 49.0,
                            DEFEV = 49.0,
                            DexEntry = 1,
                            GrowthRate = 1059860.0,
                            HP = 45.0,
                            HPEV = 45.0,
                            Height = 0.69999999999999996,
                            Name = "Bulbasaur",
                            PokedexEntry = "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.",
                            SPATK = 65.0,
                            SPATKEV = 65.0,
                            SPD = 45.0,
                            SPDEF = 65.0,
                            SPDEFEV = 65.0,
                            SPDEV = 45.0,
                            Type1 = "Grass",
                            Type2 = "Poison",
                            Weight = 6.9000000000000004
                        },
                        new
                        {
                            Id = 2,
                            ATK = 62.0,
                            ATKEV = 62.0,
                            CaptureRate = 45.0,
                            Classification = "Seed Pokemon",
                            DEF = 63.0,
                            DEFEV = 63.0,
                            DexEntry = 2,
                            GrowthRate = 1059860.0,
                            HP = 60.0,
                            HPEV = 60.0,
                            Height = 1.0,
                            Name = "Ivysaur",
                            PokedexEntry = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                            SPATK = 80.0,
                            SPATKEV = 80.0,
                            SPD = 60.0,
                            SPDEF = 80.0,
                            SPDEFEV = 80.0,
                            SPDEV = 60.0,
                            Type1 = "Grass",
                            Type2 = "Poison",
                            Weight = 13.0
                        },
                        new
                        {
                            Id = 3,
                            ATK = 82.0,
                            ATKEV = 82.0,
                            CaptureRate = 45.0,
                            Classification = "Seed Pokemon",
                            DEF = 83.0,
                            DEFEV = 83.0,
                            DexEntry = 3,
                            GrowthRate = 1059860.0,
                            HP = 80.0,
                            HPEV = 80.0,
                            Height = 2.0,
                            Name = "Venusaur",
                            PokedexEntry = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
                            SPATK = 100.0,
                            SPATKEV = 100.0,
                            SPD = 80.0,
                            SPDEF = 100.0,
                            SPDEFEV = 100.0,
                            SPDEV = 80.0,
                            Type1 = "Grass",
                            Type2 = "Poison",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = 4,
                            ATK = 52.0,
                            ATKEV = 52.0,
                            CaptureRate = 45.0,
                            Classification = "Lizard Pokemon",
                            DEF = 42.0,
                            DEFEV = 42.0,
                            DexEntry = 4,
                            GrowthRate = 1059860.0,
                            HP = 39.0,
                            HPEV = 39.0,
                            Height = 0.59999999999999998,
                            Name = "Charmander",
                            PokedexEntry = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
                            SPATK = 50.0,
                            SPATKEV = 50.0,
                            SPD = 65.0,
                            SPDEF = 50.0,
                            SPDEFEV = 50.0,
                            SPDEV = 65.0,
                            Type1 = "Fire",
                            Type2 = "",
                            Weight = 8.5
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
