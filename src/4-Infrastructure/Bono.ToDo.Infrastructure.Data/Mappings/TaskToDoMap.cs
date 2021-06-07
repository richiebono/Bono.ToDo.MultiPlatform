using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Data.Mappings
{
    public class TaskToDoMap: IEntityTypeConfiguration<TaskToDo>
    {
        public void Configure(EntityTypeBuilder<TaskToDo> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.IsDone).HasDefaultValue(false);
        }
    }
}
