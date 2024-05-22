namespace Groceries.Infrastructure.Repositories
{
    //TODO: Think about Data Models vs. Domain Entity Model for Abstracting Database from Domain Entity Models.
    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    // using Groceries.Core.Domain.Entities;
    // using Groceries.Core.Domain.Repositories;
    // using Microsoft.EntityFrameworkCore;

    // public class CommandRepository<T> : ICommandRepository<T> where T : class
    // {
    //     private readonly GroceriesDbContext _context;

    //     public CommandRepository(GroceriesDbContext context)
    //     {
    //         _context = context;
    //     }

    //     public async Task AddAsync(T entity)
    //     {
    //         await _context.Set<T>().AddAsync(entity);
    //         await _context.SaveChangesAsync();
    //     }

    //     public async Task UpdateAsync(T entity)
    //     {
    //         _context.Set<T>().Update(entity);
    //         await _context.SaveChangesAsync();
    //     }

    //     public async Task DeleteAsync(T entity)
    //     {
    //         _context.Set<T>().Remove(entity);
    //         await _context.SaveChangesAsync();
    //     }
    // }
}