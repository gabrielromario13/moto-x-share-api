using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Rentals;

public interface IRentalRepository : IRepositoryAsync<Rental>
{
    Task<bool> CheckIfMotorcycleIsRented(Guid motorcycleId);
    Task<bool> CheckActiveRentalByDeliveryRiderId(Guid deliveryRiderId);
}