using Management.Domain.Entites.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Configurations.Invoices
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> entity)
        {
            entity.HasKey(x=>x.Id);
            #region Properties
            entity.Property(b=>b.MonthOfBill).IsRequired();
            entity.Property(b => b.BillTypeEnumId).IsRequired();
            entity.Property(b => b.ApartmentId).IsRequired();
            entity.Property(b => b.BillAmount).IsRequired();
            entity.Property(b=>b.IsPaid).IsRequired();
            #endregion

            #region Foreign Key
            entity.HasOne(d => d.Apartment)
                .WithMany(b => b.Bill)
                .HasForeignKey(d => d.ApartmentId);

            #endregion

            #region Index
            
            #endregion
        }
    }
}
