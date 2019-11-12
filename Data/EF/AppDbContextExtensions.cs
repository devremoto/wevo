using Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EF
{
    public static class AppDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this AppDbContext context)
        {
            if (!context.Languages.Any())
            {
                var languages = new List<Language>
                {
                    new Language
                    {
                        Name ="português",
                        Active=true,
                        Code="pt-br"
                    },
                    new Language
                    {
                        Name ="english",
                        Active=true,
                        Code="en-us"
                    },
                    new Language
                    {
                        Name ="spanish",
                        Active=true,
                        Code="es-es"
                    }
                };

                context.Languages.AddRange(languages);
            }

            context.SaveChanges();
        }

        public static bool AllMigrationsApplied(this AppDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}
