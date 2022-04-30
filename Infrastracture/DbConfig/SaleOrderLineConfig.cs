using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.DbConfig
{
    public class SaleOrderLineConfig : IEntityTypeConfiguration<SaleOrderLine>
    {
        public void Configure(EntityTypeBuilder<SaleOrderLine> builder)
        {
            builder.Property(i => i.Quantity).HasColumnType("decimal(38,18)");
        }
    }
}
