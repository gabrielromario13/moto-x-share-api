﻿using MotoXShare.Application.Interactor.Interface.Rental;
using MotoXShare.Application.UseCase.Rental;
using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Rental;

public class GetRentalInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    GetRentalUseCase getRentalUseCase
) : InteractorAsync<GetRentalResponseDto, GetRentalRequestDto>(unitOfWork), IGetRentalInteractor
{
    protected override async Task<GetRentalResponseDto> Action(GetRentalRequestDto param) =>
        await getRentalUseCase.Action(param);
}