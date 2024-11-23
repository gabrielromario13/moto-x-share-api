using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Orders;

public interface IOrderRepository : IRepositoryAsync<Order>
{
}