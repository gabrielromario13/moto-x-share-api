using MotoXShare.Domain.Model;

namespace MotoXShare.Infraestructure.Data.Repository.Interface;

public interface IRentalRepository : IRepositoryAsync<Rental>
{
    Task<bool> CheckIfMotorcycleIsRented(Guid motorcycleId);
    Task<bool> CheckActiveRentalByDeliveryRiderId(Guid deliveryRiderId);
}