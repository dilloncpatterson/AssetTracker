using Assets.Domain;
using Microsoft.EntityFrameworkCore;
/// <summary>
/// This is where you will create the connection string to the database. 
/// Code first software database is named here. 
/// This is where the "starter data" is found. Eg). Asset types, names, etc. 
/// Make sure proper packages are added: 
///     microsoft.entityframeworkcore
/// 
/// NOTE****
/// The creation is completed in 2 steps(to be done using the Package Manager Console, 
/// Default Project: RentalProperties.Data (not RentalProperties.Domain)
/// 1. Add-Migration CreateRentalProperties 
/// 2. Update-Database (If you make changes in the entity classes, you can run this command again to update
/// the database. The Add-M igration is only needed upon creation)
/// 
/// </summary>

namespace Assets.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=Assets;
                                          Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Desktop" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            modelBuilder.Entity<Asset>().HasData(
                       new Asset
                       {
                           Id = 1,
                           TagNumber = "1001",
                           AssetTypeId = 1,
                           Manufacturer = "Dell",
                           Model = "HP Z4 G4 Workstation",
                           Description = "Gaming Desktop",
                           SerialNumber = "1DTabc1234",
                       },
                       new Asset
                       {
                           Id = 2,
                           TagNumber = "2001",
                           AssetTypeId = 2,
                           Manufacturer = "Acer",
                           Model = "UM.HT2AA.003",
                           Description = "27' Widescreen Monitor",
                           SerialNumber = "1Mdef5678",
                       },
                     new Asset
                     {
                         Id = 3,
                         TagNumber = "3001",
                         AssetTypeId = 3,
                         Manufacturer = "Avanya",
                         Model = "T7316e",
                         Description = "multi-line business phone",
                         SerialNumber = "1Pghi101",
                     }
                     );
                     
        }       
    }
}//namespace
