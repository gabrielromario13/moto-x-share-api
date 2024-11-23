﻿using MotoXShare.Application.Data.Context;
using MotoXShare.Application.UnitOfWork.Base;

namespace MotoXShare.Application.UnitOfWork;

public class EntityFrameworkUnitOfWorkAsync(ApplicationContext context) : UnitOfWorkAsync
{
    private readonly ApplicationContext _context = context ?? throw new ArgumentNullException(nameof(context));

    protected override async Task OnBeginUnitAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    protected override async Task OnCommitUnitAsync()
    {
        await _context.Database.CommitTransactionAsync();

        await _context.SaveChangesAsync();
    }

    protected override async Task OnRollbackUnitAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}