using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Orders;

public class OrderRepository(AppDbContext context)
    : RepositoryAsync<Order>(context), IOrderRepository
{
}