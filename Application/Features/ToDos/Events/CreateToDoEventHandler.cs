using Domain.Common;
using Domain.Entities.ToDo.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ToDos.Events
{
    public class CreateToDoEventHandler : INotificationHandler<CreateToDoEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CreateToDoEventHandler> _logger;
        public CreateToDoEventHandler(IMediator mediator,ILogger<CreateToDoEventHandler> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public Task Handle(CreateToDoEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Created ToDo Entitiy on Db with Id : " + notification.Id);
            return Task.CompletedTask;
        }
    }
}
