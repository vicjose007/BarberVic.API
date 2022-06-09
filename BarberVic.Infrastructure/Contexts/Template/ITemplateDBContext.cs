﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntity;

namespace BarberVic.Infrastructure.Contexts.BarberVic
{
    public interface IBarberVicDbContext : IDisposable
    {
        DatabaseFacade Database { get; }
        DbSet<T> GetDbSet<T>() where T : class, IBaseEntity;
        int SaveChanges();
        ChangeTracker ChangeTracker();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
