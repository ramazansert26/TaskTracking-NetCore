using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using Action = Ramazan.ToDo.Entittes.Concrete.Action;

namespace Ramazan.ToDo.DataAccess.EntityFrameworkCore.Mapping
{
    public class ActionMap : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Detail).HasColumnType("ntext");
            builder.HasOne(I => I.Work).WithMany(I => I.Actions).HasForeignKey(I => I.WorkId);
        }
    }
}
