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
            entity.HasIndex(x => x.Id);

            #region Properties
            entity.Property(r => r.Name).IsRequired();
            entity.Property(r => r.LastName).IsRequired();
            entity.Property(r => r.NationalIdentificationNo).IsRequired();
            entity.Property(r => r.PhoneNumber).IsRequired();
            entity.Property(r => r.Email).IsRequired();
            entity.Property(r => r.Password).IsRequired();
            entity.Property(r => r.LicansePlate);
            entity.Property(r => r.ResidentTypeEnumId);


      


            #endregion

            #region ForeignKey

            #endregion

            #region Index
            entity.HasIndex(e => new
            {
                e.Email,
                e.PhoneNumber,
                e.NationalIdentificationNo
            },
                "IX_Email_PhoneNumber_NationalIdentificationNo").IsUnique();
            #endregion
        }
    }
}

   

