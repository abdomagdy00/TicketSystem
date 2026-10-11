namespace TicketSystem.Application.Features.Categories.Services;

using Microsoft.EntityFrameworkCore;
using TicketSystem.Application.Common.Interfaces;
using TicketSystem.Application.Features.Categories.DTOs;
using TicketSystem.Application.Features.Categories.Interfaces;
using TicketSystem.Domain.Entities;

public class CategoryService : ICategoryService
{
    private readonly IAppDbcontext _context;
    public CategoryService(IAppDbcontext context)
    {
        _context =context;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .Select(c => new CategoryDto
            {
                Id=c.Id,
                Name =c.Name,
                Description =c.Description,
                CreatedAt =c.CreatedAt
            })
            .ToListAsync();
    }
    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }
    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    

    
}