using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.DeliveryRiders;

public interface IDeliveryRiderRepository : IRepositoryAsync<Domain.Model.DeliveryRider>
{
    Task<bool> CheckIfCnpjExists(string cnpj);
    Task<bool> CheckIfCnhExists(string cnh);
    Task<bool> CheckIfCnhTypeIsValid(Guid id);
}