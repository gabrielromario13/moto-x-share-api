using MediatR;
using Microsoft.AspNetCore.Http;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommands;

public record UpdateDeliveryRiderCommand(int Id, IFormFile CNHImage)
    : IRequest<ResultViewModel<bool>>;