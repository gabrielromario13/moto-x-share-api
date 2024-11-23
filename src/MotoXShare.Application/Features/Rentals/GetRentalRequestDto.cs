namespace MotoXShare.Application.Features.Rentals;

public class GetRentalRequestDto(Guid id, DateTime returnDate)
{
    public Guid Id { get; set; } = id;
    public DateTime ReturnDate { get; set; } = returnDate;
}