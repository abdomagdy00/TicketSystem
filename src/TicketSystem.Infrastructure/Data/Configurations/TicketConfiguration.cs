namespace TicketSystem.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Entities;


public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t=>t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasOne(t => t.CreatedByUser)
            .WithMany(u => u.CreatedTickets)
            .HasForeignKey(t => t.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t=>t.AssignedToAgent)
            .WithMany(u=>u.AssignedTickets)
            .HasForeignKey(t=>t.AssignedToAgentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(t => t.category)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t =>t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}