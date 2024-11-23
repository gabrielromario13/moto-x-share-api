namespace MotoXShare.Application.Features.Rentals;

public class GetRentalUseCase(IRentalRepository repository)
{
    public virtual async Task<GetRentalResponseDto> Action(GetRentalRequestDto param)
    {
        var rental = await repository.GetSingle(r => r.Id == param.Id);

        return rental is null ? default : RentalAdapter.FromDomain(rental, param.ReturnDate);
    }
}