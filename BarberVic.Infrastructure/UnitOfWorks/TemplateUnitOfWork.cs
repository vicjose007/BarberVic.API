using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntity;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.Repositories;

namespace BarberVic.Infrastructure.UnitOfWorks
{
    public class BarberVicUnitOfWork : IUnitOfWork<IBarberVicDbContext>
    {
        public IBarberVicDbContext context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public BarberVicUnitOfWork(IServiceProvider serviceProvider, IBarberVicDbContext context)
        {
            _serviceProvider = serviceProvider;
            this.context = context;
        }

        public async Task<int> Commit()
        {
            var result = await context.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity>(this)) as IRepository<TEntity>;
        }
    }
}