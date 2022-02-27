using Management.Domain.Entities.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Configurations.Invoices
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(p => p.Id);
            #region Property
            entity.Property(p=>p.UserId).IsRequired();
            entity.Property(p=>p.BillId).IsRequired();
            entity.Property(p=>p.Amount).IsRequired();
            #endregion

            #region Foreign Key
            entity.HasOne(b => b.Bill)
                .WithOne(p => p.Payment)
                .HasForeignKey<Payment>(p => p.BillId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            entity.HasOne(b => b.User)
               .WithOne(p => p.Payment)
               .HasForeignKey<Payment>(p => p.UserId)
               .OnDelete(DeleteBehavior.ClientNoAction);
            #endregion

        }
    }
}
