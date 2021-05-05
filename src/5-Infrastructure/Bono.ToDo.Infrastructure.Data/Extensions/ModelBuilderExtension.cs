﻿using Microsoft.EntityFrameworkCore;
using System;

using Bono.ToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Bono.ToDo.Domain.Models;
using Bono.ToDo.Infrastructure.Utils;

namespace Bono.ToDo.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }

            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder, Security security)
        {
            builder.Entity<User>()
                .HasData(
                    new User("Richard Bono", security.EncryptPassword("admin@123"), "Richard Bono", "Oliveira", "123.456.456-56", "richiebono@gmail.com", "+55 11-98547-3851")
                );


            return builder;
        }
    }
}
