using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;

namespace Torcar.REPOSITORY
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMark> CarMarks { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarSerial> CarSerials { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentRequest> RentRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity reference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Modified:
                            {
                                reference.ModifiedDate = DateTime.Now;
                                reference.ObjectState = ObjectState.Updated;
                                break;
                            }
                        case EntityState.Deleted:
                            {
                                reference.DeletedDate = DateTime.Now;
                                reference.ObjectState = ObjectState.Deleted;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>().HasOne(x => x.Car).WithOne(x => x.Advert).HasForeignKey<Advert>(x => x.CarId);
            modelBuilder.Entity<Advert>().HasOne(x => x.RentRequest).WithOne(x => x.Advert).HasForeignKey<RentRequest>(x => x.AdvertId);
            modelBuilder.Entity<RentRequest>().HasOne(x=>x.User).WithOne(x=>x.RentRequest).HasForeignKey<RentRequest>(x => x.UserId);
            modelBuilder.Entity<RentRequest>().HasOne(x => x.Rent).WithOne(x => x.RentRequest).HasForeignKey<Rent>(x => x.RentRequestId);
            modelBuilder.Entity<Car>().HasOne(x=>x.CarSerial).WithMany(x=>x.Cars).HasForeignKey(x=>x.CarSerialId);
            modelBuilder.Entity<CarSerial>().HasOne(x => x.CarModel).WithMany(x => x.CarSerials).HasForeignKey(x => x.CarModelId);
            modelBuilder.Entity<CarModel>().HasOne(x => x.CarMark).WithMany(x => x.CarModels).HasForeignKey(x => x.CarMarkId);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
