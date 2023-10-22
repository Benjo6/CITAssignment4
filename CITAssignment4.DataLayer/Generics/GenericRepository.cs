using CITAssignment4.DataLayer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CITAssignment4.DataLayer.Generics;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CITDbContext _context;
    private readonly ILogger _logger;

    public GenericRepository(CITDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<T> GetById(int id)
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while fetching data by Id: {id}");
            throw;
        }
    }

    public async Task<List<T>> GetAll()
    {
        try
        {
            return await _context.Set<T>().ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching all data");
            throw;
        }
    }

    public async Task<T> Add(T entity)
    {
        try
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding data");
            throw;
        }
    }

    public async Task<bool> Update(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "Error occurred while updating data");
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await GetById(id);
        
        if (entity == null)
        {
            return false;
        }

        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting data with Id: {id}");
            throw;
        }
    }
}