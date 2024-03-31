namespace MotoXShare.Domain.Dto.Rental;

public class GetRentalRequestDto
{
    public Guid Id { get; set; }
    public DateTime ReturnDate { get; set; }
}