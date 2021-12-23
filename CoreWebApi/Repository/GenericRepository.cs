using HotelListing22CoreWebApi.Data;
using HotelListing22CoreWebApi.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelListing22CoreWebApi.Repository
{
    /// <summary>
    /// this class uses the abstract prototype functions from the interface
    ///  to provide the "real" code.  
    ///  its generic because its going to be used 
    ///  for database operations for classes that represent different tables
    ///  generic means i have a T inside lessthan greater than angle brackets
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //from builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(cs)) ;
        //     in Program.cs startup
        private readonly DatabaseContext _context;  //see Program.cs for this. but both have to do with dbcontext
        private readonly DbSet<T> _db;              //see DatabaseContext.cs for this

        public GenericRepository(DatabaseContext databaseContext)
        {
            this._context = databaseContext;        //this is known as dependency injection
            this._db      = this._context.Set<T>(); //forinstance, public DbSet<Country> Countries { get; set; }
        }

        async Task IGenericRepository<T>.Delete(int id)
        {
            var entity  = await _db.FindAsync(id);
            if (entity == null) return;
            _db.Remove(entity);
        }

        void IGenericRepository<T>.DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        /// <summary>
        /// called like this in the CountryController.cs
        /// var countries = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> {"Hotels"});
        /// </summary>
        /// <param name="expression">q => q.Id == id            </param>
        /// <param name="includes"  >new List<string> {"Hotels"}</param>
        /// <returns></returns>
        async Task<T> IGenericRepository<T>.Get(Expression<Func<T, bool>> expression, List<string> includes)
        {
            //includes are for automatically filling in the ForeignKey defined in Hotel.cs
            IQueryable<T> query = _db;
            if(includes != null) //if not null then include the extra strings in the query
            {
                foreach(var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            string q=query.ToQueryString();
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        async Task<IList<T>> IGenericRepository<T>.GetAll(Expression<Func<T, bool>> expression, 
                                                    Func<IQueryable<T>, 
                                                    IOrderedQueryable<T>> orderBy, 
                                                    List<string> includes)
        {
            IQueryable<T> query = _db;
            if(expression      != null)
            {
                query    = query.Where(expression); 
            }
            if(includes != null)
            {
                foreach(var includesProperty in includes)
                {
                    query = query.Include(includesProperty);
                }
            }
            if(orderBy   != null)
            {
                query      = orderBy(query);
            }
            return await query.AsNoTracking().ToArrayAsync();
        }

        async Task IGenericRepository<T>.Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        async Task IGenericRepository<T>.InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        void IGenericRepository<T>.Update(T entity)
        {
            _db.Attach(entity); //performs some validation and existance of the entity in the db
            _context.Entry(entity).State = EntityState.Modified; //sort of like the old isdirty
        }
    }
}
