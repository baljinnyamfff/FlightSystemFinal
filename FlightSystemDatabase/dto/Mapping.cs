using FlightSystemDatabase.dto;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.dto
{
    public static class Mapping
    {
        public static FlightDto ToDto(this Flight flight)
        {
            return new FlightDto
            {
                FlightNumber = flight.FlightNumber,
                Destination = flight.Destination,
                DepartureTime = flight.DepartureTime,
                Status = flight.Status.ToString()
            };
        }

        public static SeatDto ToDto(this Seat seat)
        {
            return new SeatDto
            {
                Id = seat.Id,
                SeatNumber = seat.SeatNumber,
                IsAssigned = seat.IsAssigned,
                FlightId = seat.FlightId,
                PassengerId = seat.PassengerId
            };
        }

        public static PassengerDto ToDto(this Passenger passenger)
        {
            return new PassengerDto
            {
                Id = passenger.Id,
                Name = passenger.Name,
                PassportNumber = passenger.PassportNumber,
                FlightId = passenger.FlightId,
                SeatId = passenger.SeatId
            };
        }

        public static BoardingPassDto ToDto(this BoardingPass boardingPass)
        {
            return new BoardingPassDto
            {
                Id = boardingPass.Id,
                PassengerId = boardingPass.PassengerId,
                SeatId = boardingPass.SeatId,
                FlightId = boardingPass.FlightId,
                IssuedAt = boardingPass.IssuedAt
            };
        }

        public static Flight ToEntity(this FlightDto dto)
        {
            return new Flight
            {
                Id = dto.Id,
                FlightNumber = dto.FlightNumber,
                Destination = dto.Destination,
                DepartureTime = dto.DepartureTime,
                Status = Enum.Parse<FlightStatus>(dto.Status)
            };
        }

        public static Seat ToEntity(this SeatDto dto)
        {
            return new Seat
            {
                Id = dto.Id,
                SeatNumber = dto.SeatNumber,
                IsAssigned = dto.IsAssigned,
                FlightId = dto.FlightId,
                PassengerId = dto.PassengerId
            };
        }

        public static Passenger ToEntity(this PassengerDto dto)
        {
            return new Passenger
            {
                Id = dto.Id,
                Name = dto.Name,
                PassportNumber = dto.PassportNumber,
                FlightId = dto.FlightId,
                SeatId = dto.SeatId
            };
        }

        public static BoardingPass ToEntity(this BoardingPassDto dto)
        {
            return new BoardingPass
            {
                Id = dto.Id,
                PassengerId = dto.PassengerId,
                SeatId = dto.SeatId,
                FlightId = dto.FlightId,
                IssuedAt = dto.IssuedAt
            };
        }
    }
}