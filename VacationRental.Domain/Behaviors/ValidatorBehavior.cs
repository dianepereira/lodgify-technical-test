using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VacationRental.Domain.Core.Exceptions;

namespace VacationRental.Domain.Behaviors
{
    public sealed class ValidatorBehavior<TOrderCommand, TResponse> : IPipelineBehavior<TOrderCommand, TResponse> where TOrderCommand : IRequest<TResponse>
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; 
        }

        public Task<TResponse> Handle(TOrderCommand request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var commandValidator = _serviceProvider.GetService<FluentValidation.IValidator<TOrderCommand>>();

            if (commandValidator != null)
            {
                var result = commandValidator.Validate(request);

                if (!result.IsValid)
                    throw new ValidationException(result);
            }

            return next();
        }
    }
}
