using MediatR;
using Microsoft.AspNetCore.Http;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommand;

public class UpdateDeliveryRiderCommand(int id, IFormFile cnhImage) : IRequest<ResultViewModel<bool>>
{
    public int Id { get; set; } = id;
    public IFormFile CnhImage { get; set; } = cnhImage;
}