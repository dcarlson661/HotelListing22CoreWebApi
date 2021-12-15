using Microsoft.EntityFrameworkCore;

namespace HotelListing22CoreWebApi.Data
{
    public class DatabaseContext :DbContext
    {
        // must add a constructor. you can type "ctor" and tap tap to have vs create it for you
        public DatabaseContext()
        {

        }
        //remember to construct the base with : base(options) which passes options to the base
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        
        //this override is to set some default data and its override is in DbContext
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Cayman Island",
                    ShortName = "CI"
                }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Comfort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Palldium",
                    Address = "Nassua",
                    CountryId = 2,
                    Rating = 4
                }
            );
        }

    }//end class DatabaseContext:DbContext
}//end namespace HotelListing22CoreWebApi.Data


