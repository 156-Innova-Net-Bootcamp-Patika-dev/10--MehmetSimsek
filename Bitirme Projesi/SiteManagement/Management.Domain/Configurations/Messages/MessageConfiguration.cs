using Management.Domain.Entites.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Configurations.Messages
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);
            #region Properties
            builder.Property(m=>m.Text);
            builder.Property(m => m.MessageSeenInfoEnumId);
            builder.Property(m => m.SenderId).IsRequired();
            builder.Property(m => m.RecieverId).IsRequired();

            #endregion


            #region Foreign Key
           
            //builder.HasOne(u => u.MessageSender)
            //    .WithMany(m => m.Sender)
            //    .HasForeignKey(u => u.SenderId)
            //    .OnDelete(DeleteBehavior.ClientNoAction)
            //    .HasPrincipalKey(m=>m.Id);
            //builder.HasOne(u => u.MessageReciever)
            //    .WithMany(m =>m.)
            //    .HasForeignKey(u=>u.RecieverId)
            //    .OnDelete(DeleteBehavior.ClientNoAction)
            //    .HasPrincipalKey(m=>m.Id);
                
            #endregion


            #region Index
            #endregion
        }
    }
}
