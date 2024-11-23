using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Rentals;

public interface ISaveRentalInteractor : IInteractorAsync<Guid, SaveRentalRequestDto>
{
}