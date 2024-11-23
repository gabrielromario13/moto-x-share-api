using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Orders;

public class OrderRepository(ApplicationContext context)
    : RepositoryAsync<Order>(context), IOrderRepository
{
}