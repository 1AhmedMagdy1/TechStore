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
    internal class CustomerAddressConfigurations : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
           builder.HasKey(ca => ca.Id);
            builder.Property(ca => ca.PostalCode).IsRequired();
            builder.Property(ca => ca.City).IsRequired().HasMaxLength(100);
            builder.Property(ca => ca.ShippingAddress).IsRequired().HasMaxLength(200);
            builder.HasOne(ca => ca.User)
             .WithMany(u => u.CustomerAddresses)
             .HasForeignKey(ca => ca.UserId)
             .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
