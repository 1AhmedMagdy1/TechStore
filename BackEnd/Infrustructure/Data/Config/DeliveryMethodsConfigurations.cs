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
    public class DeliveryMethodsConfigurations : IEntityTypeConfiguration<DeliveryMethods>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethods> builder)
        {
            builder.HasKey(dm => dm.Id);
            builder.Property(dm => dm.Name).IsRequired().HasMaxLength(100);
            builder.Property(dm => dm.Description).IsRequired().HasMaxLength(500);
            builder.Property(dm => dm.DeliveryTime).IsRequired().HasMaxLength(100);
            builder.Property(dm => dm.Price).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
