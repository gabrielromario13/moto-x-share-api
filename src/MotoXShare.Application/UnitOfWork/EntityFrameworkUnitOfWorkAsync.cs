using MotoXShare.Application.UnitOfWork.Base;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Application.UnitOfWork;

public class EntityFrameworkUnitOfWorkAsync(AppDbContext context) : UnitOfWorkAsync
{
    private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

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