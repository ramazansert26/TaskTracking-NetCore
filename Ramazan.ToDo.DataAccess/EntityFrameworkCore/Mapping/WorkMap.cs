using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Mapping
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(200);
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.HasOne(I => I.Priority).WithMany(I => I.Works).HasForeignKey(I => I.PriorityId);
        }
    }
}
