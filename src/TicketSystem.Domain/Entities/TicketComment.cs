namespace TicketSystem.Domain.Entities;

using TicketSystem.Domain.Common;

public class TicketComment : BaseEntity
{
    public string Content { get; set; }=null!;

    // Foreign Keys
    public int TicketId { get; set; }
    public int UserId { get; set; }   

    // Navigation Properties
    public Ticket Ticket { get; set; } = null!;
    public User User { get; set; } = null!;
}