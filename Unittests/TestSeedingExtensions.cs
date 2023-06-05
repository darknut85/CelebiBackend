﻿using Microsoft.AspNetCore.Identity;
using Migrations;
using Objects;
using System.Diagnostics.CodeAnalysis;
using TestSupport.EfHelpers;

namespace Unittests
{
    [ExcludeFromCodeCoverage]
    public static class TestSeedingExtensions
    {
        public static void PokemonSetup(this DataContext dataContext)
        {
            List<Pokemon> pokemons = new List<Pokemon>()
            {
                new Pokemon() 
                { Name = "Mewtwo", DexEntry = 150, Type1 = "Psychic", Type2 = "", Height = 2, Weight = 2, Classification = "???", PokedexEntry = "..." },
                new Pokemon() 
                { Name = "Mew", DexEntry = 151, Type1 = "Psychic", Type2 = "", Height = 2, Weight = 2, Classification = "???", PokedexEntry = "..." }
            };
            dataContext.AddRange(pokemons);

            List<Move> moves = new List<Move>()
            {
                new Move()
                { Name = "Psychic", Type = "Psychic", PowerPoints = 0, Target = "", Priority = 0, Accuracy = 0, Id = 150, EffectRate = 0, BattleEffect = "", BasePower = 0},
                new Move()
                { Name = "FireBlast", Type = "Fire", PowerPoints = 0, Target = "", Priority = 0, Accuracy = 0, Id = 151, EffectRate = 0, BattleEffect = "", BasePower = 0}

            };
            dataContext.AddRange(moves);

            List<LevelupMove> levelups = new List<LevelupMove>()
            {
                new LevelupMove()
                { Id = 200, Level = 2, MoveId = 2, PokemonId = 2 },
                new LevelupMove()
                { Id = 201, Level = 3, MoveId = 3, PokemonId = 3}
            };
            dataContext.AddRange(levelups);

            List<IdentityUser> identityUsers = new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    UserName = "Juan",
                    PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                    Email = "new.juan@newJuan.com",
                    NormalizedEmail = "NEW.JUAN@NEWJUAN.COM",
                    NormalizedUserName = "NEWJUAN",
                    EmailConfirmed = true
                },
                new IdentityUser()
                {
                    UserName = "Emma",
                    PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                    Email = "new.Emma@newv.com",
                    NormalizedEmail = "NEW.EMMA@NEWEMMA.COM",
                    NormalizedUserName = "NEWEMMA",
                    EmailConfirmed = true
                }
            };
            dataContext.AddRange(identityUsers);

            dataContext.SaveChanges();
        }

        public static void DefaultSetup(this DataContext context)
        {
            context.Database.EnsureClean();
            context.PokemonSetup();
            context.ChangeTracker.Clear();
        }
    }
}
