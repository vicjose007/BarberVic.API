using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntity;
using BarberVic.Domain.Entities;
using BarberVic.Domain.Models;

namespace BarberVic.Infrastructure.Contexts.BarberVic
{
    public class BarberVicDbContext : BaseDbContext, IBarberVicDbContext
    {
        public BarberVicDbContext(DbContextOptions<BarberVicDbContext> options,
            IOptions<AppSettings> appSettings)
            : base(options, appSettings)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();

        ChangeTracker IBarberVicDbContext.ChangeTracker()
        {
            return base.ChangeTracker;
        }
    }
}
