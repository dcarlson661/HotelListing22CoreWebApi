using HotelListing22CoreWebApi.Data;
using Microsoft.AspNetCore.Identity;

namespace HotelListing22CoreWebApi
{
    //this static class so i don't have to keep adding stuff in Program.cs (the "startup" class so to speak)
    //  think of it as an abstract to Program.cs
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            //here's where i add policy rules for database identities i'm going to use
            var builder = services.AddIdentityCore<ApiUser>(q => { q.User.RequireUniqueEmail = true; });

            //i'm building up everything that needs to be added to the services
            // in Program.cs this is known as builder.Services
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

        }

    }//end static class ServiceEntensions
}
