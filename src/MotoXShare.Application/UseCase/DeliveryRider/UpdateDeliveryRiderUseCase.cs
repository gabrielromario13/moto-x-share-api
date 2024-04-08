using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.DeliveryRider;

public class UpdateDeliveryRiderUseCase
{
    private readonly IDeliveryRiderRepository _repository;
    private readonly NotificationHandler _notificationHandler;
    private static readonly string PATH = @"C:\CnhImages\";
    private readonly string[] ValidExtensions = [".png", ".bmp"];

    public UpdateDeliveryRiderUseCase(
        IDeliveryRiderRepository repository,
        NotificationHandler notificationHandler)
    {
        _repository = repository;
        _notificationHandler = notificationHandler;

        Directory.CreateDirectory(PATH);
    }

    public virtual async Task<bool> Action(UpdateDeliveryRiderRequestDto param)
    {
        var deliveryRider = await _repository.GetById(param.Id);

        if (deliveryRider is null)
            return false;

        var fileName = param.CnhImage.FileName;

        var validExtension = ValidExtensions.Contains(Path.GetExtension(fileName).ToLower());

        if (!validExtension)
        {
            _notificationHandler.Add(new("Formato de arquivo inválido. Formatos aceitos: .png ou .bmp.", "InvalidExtension"));
            return false;
        }

        using (var stream = new FileStream(PATH + fileName, FileMode.Create))
        {
            param.CnhImage.CopyTo(stream);
        }

        deliveryRider.CNHImage = fileName;
        await _repository.Update(deliveryRider);

        return true;
    }
}