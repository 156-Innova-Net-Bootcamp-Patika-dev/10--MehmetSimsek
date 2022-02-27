using Management.Domain.Configurations.Buildings;
using Management.Domain.Configurations.Invoices;
using Management.Domain.Configurations.Messages;
using Management.Domain.Configurations.Residents;
using Management.Domain.Entites.Messages;
using Management.Domain.Entities.Authentications;
using Management.Domain.Entities.Buildings;
using Management.Domain.Entities.Commons;
using Management.Domain.Entities.Residents;
using Management.Domain.Entites.Invoices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Domain.Entities.Invoices;

namespace Management.Infrastructure.Contracts.Persistance
{
    public class ApplicationContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        #region Buildings
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<Block> Blocks { get; set; }
        #endregion
        #region Resident
        public DbSet<Resident> Residents { get; set; }
        #endregion
        #region Invoices
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        #endregion
        #region Messages
        public DbSet<Message> Messages { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BlockConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
           
            
            ///<summary>
            ///To make 2 Foreign Key from same table to another table.
            ///</summary>
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.MessageReciever)
                    .WithMany(p => p.Reciever)
                    .HasForeignKey(d => d.RecieverId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.MessageSender)
                    .WithMany(p => p.Sender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithOne(p => p.Payment)
                    .HasForeignKey<Payment>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(d => d.Bill)
                    .WithOne(p => p.Payment)
                    .HasForeignKey<Payment>(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            });


            base.OnModelCreating(modelBuilder);





        }

    }
}
