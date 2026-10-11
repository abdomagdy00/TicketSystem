namespace TicketSystem.Application.Common.Interfaces; 

using Microsoft.EntityFrameworkCore;
using TicketSystem.Domain.Entities;

public interface IAppDbContext 
{
    DbSet<User> Users { get; }
    DbSet<Category> Categories { get; }
    DbSet<Ticket> Tickets { get; }
    DbSet<TicketComment> TicketComments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}