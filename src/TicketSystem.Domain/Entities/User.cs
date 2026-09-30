namespace TicketSystem.Domain.Entities;

using TicketSystem.Domain.Common;
using TicketSystem.Domain.Enums;


public class User: BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; }=null!;
    public UserRole Role { get; set; } =UserRole.Customer;

    public ICollection<Ticket> CreatedTickets { get; set; } =new List<Ticket>();

    public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    public ICollection<TicketComment> Comments { get; set; } =new List<TicketComment>();
}