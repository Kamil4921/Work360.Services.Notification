using MediatR;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class CreateLeaveHandler(ILeaveRepository) : IRequestHandler<CreateLeave>
{
    public Task Handle(CreateLeave request, CancellationToken cancellationToken)
    {
        //TODO add entity and implementation
    }
}