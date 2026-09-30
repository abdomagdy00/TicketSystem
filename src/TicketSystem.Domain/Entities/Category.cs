namespace TicketSystem.Domain.Entities;

using TicketSystem.Domain.Common;

public class Category : BaseEntity
{
    public string Name { get; set; } =null!;
    public string Description { get; set; } =null!;

    public ICollection<Ticket> Tickets { get; set; } =new List<Ticket>();
}