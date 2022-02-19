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
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> entity)
        {
            entity.HasKey(x=>x.Id);

            #region Properties
            entity.Property(x => x.Name);
            #endregion

            #region ForeignKey


            #endregion

            #region Index
            entity.HasIndex(e => new { e.Name }, "IX_Name").IsUnique();
            #endregion


        }
    }
}
