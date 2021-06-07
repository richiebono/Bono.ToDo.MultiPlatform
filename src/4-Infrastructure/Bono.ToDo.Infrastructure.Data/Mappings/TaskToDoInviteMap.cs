using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Data.Mappings
{
    public class TaskToDoInviteMap: IEntityTypeConfiguration<TaskToDoInvite>
    {
        public void Configure(EntityTypeBuilder<TaskToDoInvite> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Email).IsRequired();            
        }
    }
}
