using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.UnitOfWork.Base;

namespace MotoXShare.Infraestructure.UnitOfWork;

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