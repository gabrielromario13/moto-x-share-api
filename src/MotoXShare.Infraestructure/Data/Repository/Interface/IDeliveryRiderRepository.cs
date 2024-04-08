using MotoXShare.Domain.Model;

namespace MotoXShare.Infraestructure.Data.Repository.Interface;

public interface IDeliveryRiderRepository : IRepositoryAsync<DeliveryRider>
{
    Task<bool> CheckIfCnpjExists(string cnpj);
    Task<bool> CheckIfCnhExists(string cnh);
    Task<bool> CheckIfCnhTypeIsValid(Guid id);
}