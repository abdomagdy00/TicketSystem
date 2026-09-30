namespace TicketSystem.Domain.Entities;

using TicketSystem.Domain.Common;
using TicketSystem.Domain.Enums;



public class Ticket :BaseEntity
{
    public string Title { get; set; }=null!;
    public string Description { get; set; }=null!;
    public TicketPriority priority { get; set; } =TicketPriority.Medium;
    public TicketStatus Status { get; set; }=TicketStatus.Open;
    public DateTime? UpdateAt { get; set; } 

    // Foreign Keys
    public int CategoryId { get; set; }
    public int CreatedByUserId { get; set; }
    public int? AssignedToAgentId { get; set; }   

    // Navigation Properties
    public Category category { get; set; }=null!;
    public User CreatedByUser { get; set; } = null!;
    public User? AssignedToAgent { get; set; }
    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
}