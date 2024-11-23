using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Rentals;

public interface IRentalRepository : IRepositoryAsync<Rental>
{
    Task<bool> CheckIfMotorcycleIsRented(Guid motorcycleId);
    Task<bool> CheckActiveRentalByDeliveryRiderId(Guid deliveryRiderId);
}