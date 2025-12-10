using Core.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Data.Config
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o =>  o.Id);
            builder.Property(o=>o.FullName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Email).HasMaxLength(100);
            builder.Property(o => o.PhoneNumber).IsRequired();
            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(o=>o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.OrderItems)
           .WithOne(oi => oi.Order)
           .HasForeignKey(oi => oi.OrderId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.CustomerAddress).WithMany();
        }
    }
}
