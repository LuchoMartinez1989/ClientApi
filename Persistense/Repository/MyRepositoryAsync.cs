using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistense.Repository
{

    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly DbContext _dbContext;
        /// <summary>
        /// metodo para crear contexto de BD
        /// </summary>
        /// <param name="dbContext"></param>
        public MyRepositoryAsync(DbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
