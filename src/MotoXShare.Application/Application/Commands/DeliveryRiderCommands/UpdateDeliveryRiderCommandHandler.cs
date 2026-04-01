using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommands;

public class UpdateDeliveryRiderCommandHandler
    : IRequestHandler<UpdateDeliveryRiderCommand, ResultViewModel>
{
    private AppDbContext _context;
    private const string Path = @"C:\CnhImages\";
    private readonly string[] _validExtensions = [".png", ".bmp"];

    public UpdateDeliveryRiderCommandHandler(AppDbContext context)
    {
        _context = context;

        Directory.CreateDirectory(Path);
    }

    public virtual async Task<ResultViewModel> Handle(
        UpdateDeliveryRiderCommand command,
        CancellationToken cancellationToken)
    {
        var deliveryRider = await _context.DeliveryRiders.FirstOrDefaultAsync(x => x.Id == command.Id);

        if (deliveryRider is null)
            return ResultViewModel.Error("Entregador não encontrado.");

        var fileName = command.CNHImage.FileName;

        var validExtension = _validExtensions.Contains(System.IO.Path.GetExtension(fileName).ToLower());

        if (!validExtension)
            return ResultViewModel
                .Error("Formato de arquivo inválido. Formatos aceitos: .png ou .bmp.");

        await using (var stream = new FileStream(Path + fileName, FileMode.Create))
        {
            await command.CNHImage.CopyToAsync(stream);
        }

        deliveryRider.CNHImageUrl = fileName;
        _context.DeliveryRiders.Update(deliveryRider);
        await _context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}