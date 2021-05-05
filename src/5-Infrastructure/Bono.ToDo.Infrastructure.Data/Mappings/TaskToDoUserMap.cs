using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Data.Mappings
{
    public class TaskToDoUserMap: IEntityTypeConfiguration<TaskToDoUser>
    {
        public void Configure(EntityTypeBuilder<TaskToDoUser> builder)
        {
            builder.Property(x => x.Id).IsRequired();            
        }
    }
}
