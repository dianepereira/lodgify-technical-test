using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Commands.CreateRental
{
    public class CreateRentalHandler : IRequestHandler<CreateRentalCommand, CreateRentalResponse>
    {
        public CreateRentalHandler() { }

        public Task<CreateRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
