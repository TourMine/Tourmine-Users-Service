using MediatR;

namespace Tourmine.Users.Application.UseCases
{
    public abstract class BaseUseCase
    {
        protected readonly IMediator mediator;

        protected BaseUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
    }
}
