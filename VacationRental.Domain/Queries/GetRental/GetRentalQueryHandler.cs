using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalQueryHandler : IRequestHandler<GetRentalQuery, GetRentalResponse>
    {
        private readonly IRepository<Rental> _rentalRepository;

        public GetRentalQueryHandler(IRepository<Rental> rentalRepository) 
        {
            _rentalRepository = rentalRepository;
        }

        public Task<GetRentalResponse> Handle(GetRentalQuery request, CancellationToken cancellationToken)
        {
            var rental = _rentalRepository.Get(request.Id);

            if (rental == null)
                throw new RentalNotFoundException(request.Id);

            return Task.FromResult(GetRentalResponse.From(rental));
        }
    }
}
