using Management.Domain.Configurations.Commons;
using Management.Domain.Entities.Residents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Configurations.Residents
{
    public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> entity)
        {
            entity.HasKey(x => x.Id);

            #region Properties
            entity.Property(r => r.UserId).IsRequired();
            entity.Property(r => r.ApartmentId).IsRequired();

            entity.Property(r => r.NationalIdentificationNo).IsRequired();
            entity.Property(r => r.PhoneNumber).IsRequired();

        
            entity.Property(r => r.LicansePlate).HasDefaultValue(null);
            entity.Property(r => r.ResidentTypeEnumId).HasDefaultValue(2);


            #endregion

            // For One User To One Resident, also 1 to 1 relationship for apartment.
            #region ForeignKey
            entity.HasOne(b => b.User)
               .WithOne(r => r.Resident)
               .HasForeignKey<Resident>(r => r.UserId)
              .OnDelete(DeleteBehavior.ClientNoAction);

            entity.HasOne(a => a.Apartment)
                .WithOne(r => r.Resident)
                .HasForeignKey<Resident>(r => r.ApartmentId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            #endregion

            #region Index
            entity.HasIndex(e => new
            {
               
                e.PhoneNumber,
                e.NationalIdentificationNo,
                e.UserId,
                e.ApartmentId
            },
                "IX_PhoneNumber_NationalIdentificationNo_UserId_ApartmentId").IsUnique();
            #endregion
        }
    }
}

   

