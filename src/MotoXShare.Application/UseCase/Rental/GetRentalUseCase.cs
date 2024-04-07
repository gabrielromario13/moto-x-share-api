using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Rental;

public class GetRentalUseCase(IRentalRepository repository)
{
    private readonly IRentalRepository _repository = repository;

    public virtual async Task<GetRentalResponseDto> Action(GetRentalRequestDto param)
    {
        var rental = await _repository.GetSingle(r => r.Id == param.Id);

        if (rental is null) 
            return default;

        return RentalAdapter.FromDomain(rental, param.ReturnDate);
    }
}