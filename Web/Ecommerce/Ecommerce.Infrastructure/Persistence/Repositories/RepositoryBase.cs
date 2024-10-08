﻿using Ecommerce.Domain.Common;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    protected readonly EcommerceDbContext _context;

    protected RepositoryBase(EcommerceDbContext context)
    {
        _context = context;
    }

    public TEntity Create(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<TEntity>().Add(entity);

        return entity;
    }

    public void Delete(int id)
    {
        var entity = GetOrThrow(id);

        _context.Set<TEntity>().Remove(entity);
    }
    public List<TEntity> GetAll()
        => _context.Set<TEntity>().AsNoTracking().ToList();

    public TEntity GetById(int id)
        => GetOrThrow(id);

    public void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<TEntity>().Update(entity);
    }

    private TEntity GetOrThrow(int id)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        if (entity is null)
        {
            throw new EntityNotFoundException($"{typeof(TEntity)} with id: {id} not found.");
        }

        return entity;
    }
}
