using Management.Domain.Configurations.Commons;
using Management.Domain.Entities.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Configurations.Buildings
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> entity)
        {

            entity.HasKey(a=>a.Id);
            #region Properties
            entity.Property(a => a.BlockId).IsRequired();
            entity.Property(a => a.HasResident).IsRequired();
            entity.Property(a => a.ApartmentTypeId).IsRequired();
            entity.Property(a => a.FloorNumber).IsRequired();
            entity.Property(a => a.ApartmentNumber).IsRequired();
            #endregion

            #region ForeignKey
            ///<summary>
            ///one apartment has only one apartment type
            ///apartment type can include MORE THAN ONE apartments
            ///1 to n relationship
            ///</summary>
            ///



            entity.HasOne(b => b.ApartmentType)
                .WithMany(a => a.Apartments)
                .HasForeignKey(b => b.ApartmentTypeId)
               .OnDelete(DeleteBehavior.ClientNoAction);

            entity.HasOne(c => c.Block)
                .WithMany(a => a.Apartments)
                .HasForeignKey(c => c.BlockId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            #endregion
            #region Index


            #endregion
        }
    }
}
