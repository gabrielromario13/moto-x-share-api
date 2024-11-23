using MotoXShare.Application.Features.Notifications;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class UpdateDeliveryRiderUseCase
{
    private readonly IDeliveryRiderRepository _repository;
    private readonly NotificationHandler _notificationHandler;
    private const string Path = @"C:\CnhImages\";
    private readonly string[] _validExtensions = [".png", ".bmp"];

    public UpdateDeliveryRiderUseCase(
        IDeliveryRiderRepository repository,
        NotificationHandler notificationHandler)
    {
        _repository = repository;
        _notificationHandler = notificationHandler;

        Directory.CreateDirectory(Path);
    }

    public virtual async Task<bool> Action(UpdateDeliveryRiderRequestDto param)
    {
        var deliveryRider = await _repository.GetById(param.Id);

        if (deliveryRider is null)
            return false;

        var fileName = param.CnhImage.FileName;

        var validExtension = _validExtensions.Contains(System.IO.Path.GetExtension(fileName).ToLower());

        if (!validExtension)
        {
            _notificationHandler.Add(new("Formato de arquivo inválido. Formatos aceitos: .png ou .bmp.", "InvalidExtension"));
            return false;
        }

        await using (var stream = new FileStream(Path + fileName, FileMode.Create))
        {
            await param.CnhImage.CopyToAsync(stream);
        }

        deliveryRider.CNHImage = fileName;
        await _repository.Update(deliveryRider);

        return true;
    }
}