using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public sealed class MyAppDbContext : DbContext,IUnitOfWork
    {
        private readonly IPublisher _publisher;
        public MyAppDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher; 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await PublishDomainEventsAsync();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker.Entries<BaseEntity>().Select(x => x.Entity).SelectMany(x =>
            {
                var events = x.GetDomainEvents();
                x.ClearDomainEvents();
                return events;
            }).ToList();

            if (domainEvents.Any())
            {
                foreach (var domainEvent in domainEvents)
                {
                    try
                    {
                        await _publisher.Publish(domainEvent);
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception (e.g., retry mechanism)
                        Console.WriteLine($"Failed to publish event: {ex.Message}");
                    }
                }
            }
        }
    }
}
