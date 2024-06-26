﻿using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Model;

public class DeliveryRiderNotification : BaseEntity
{
    public Guid OrderId { get; set; }
    public IList<Guid> DeliveryRidersIds { get; set; }

    public virtual Order Order { get; set; }
}