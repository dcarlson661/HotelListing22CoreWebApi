using HotelListing22CoreWebApi.Data;

namespace HotelListing22CoreWebApi.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        // these generic interfaces
        //  will generate a lamba public IGenericRepository<Country> Countries => throw new NotImplementedException();
        //  in classes that implement this interface
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
