namespace TicketSystem.Application.Features.Categories.Interfaces;

using TicketSystem.Application.Features.Categories.DTOs;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
}