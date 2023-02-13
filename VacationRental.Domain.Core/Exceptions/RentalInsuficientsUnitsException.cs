﻿namespace VacationRental.Domain.Core.Exceptions
{
    public class RentalInsuficientsUnitsException : Exception
    { 
        public RentalInsuficientsUnitsException() { }

        public RentalInsuficientsUnitsException(int rentalUnits, int bookingUnits) : base($"It is not possible to rent {bookingUnits} unit, the rental has only has {rentalUnits} units") { }

    }
}
