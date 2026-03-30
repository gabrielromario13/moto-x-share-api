using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommand;

public class UpdateDeliveryRiderCommandHandler : IRequestHandler<UpdateDeliveryRiderCommand, ResultViewModel<bool>>
{
    private AppDbContext _context;
    private const string Path = @"C:\CnhImages\";
    private readonly string[] _validExtensions = [".png", ".bmp"];

    public UpdateDeliveryRiderCommandHandler(AppDbContext context)
    {
        _context = context;

        Directory.CreateDirectory(Path);
    }

    public virtual async Task<ResultViewModel<bool>> Handle(
        UpdateDeliveryRiderCommand request,
        CancellationToken cancellationToken)
    {
        var deliveryRider = await _context.DeliveryRiders.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (deliveryRider is null)
            return ResultViewModel<bool>.Error(string.Empty);

        var fileName = request.CnhImage.FileName;

        var validExtension = _validExtensions.Contains(System.IO.Path.GetExtension(fileName).ToLower());

        if (!validExtension)
        {
            return ResultViewModel<bool>.Error("Formato de arquivo inválido. Formatos aceitos: .png ou .bmp.");
        }

        await using (var stream = new FileStream(Path + fileName, FileMode.Create))
        {
            await request.CnhImage.CopyToAsync(stream);
        }

        deliveryRider.CNHImageUrl = fileName;
        _context.DeliveryRiders.Update(deliveryRider);
        await _context.SaveChangesAsync();

        return ResultViewModel<bool>.Success(true);
    }
}