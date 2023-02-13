using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Commands.CreateRental
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreateRentalResponse>
    {
        private readonly IRepository<Rental> _rentalRepository;

        public CreateRentalCommandHandler(IRepository<Rental> rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public Task<CreateRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = _rentalRepository.Add(Rental.Create(request.Units, request.PreparationTimeInDays));
            return Task.FromResult(CreateRentalResponse.From(rental));
        }
    }
}
