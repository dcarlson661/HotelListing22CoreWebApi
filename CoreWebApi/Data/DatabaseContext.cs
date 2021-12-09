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

    }//end class DatabaseContext:DbContext
}//end namespace HotelListing22CoreWebApi.Data


