﻿using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Model;

public class DeliveryRider(Guid id) : User(id)
{
    public string CNPJ { get; set; } //TODO: Validate, it must be unique.

    //TODO: Check if I should create an CNH class.
    public string CNH { get; set; } //TODO: Validate, it must be unique.
    public CnhTypes CNHType { get; set; }
    public string CNHImage { get; set; } //File format must be png or bpm.
                                         //Can't be storaged in the DB, use (local disk, amazon s3, minIO, etc...) instead!
    public Rental Rental { get; set; }
}