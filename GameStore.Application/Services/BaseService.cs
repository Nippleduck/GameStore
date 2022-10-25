using GameStore.Persistence.UOF;

namespace GameStore.Application.Services
{
    public abstract class BaseService
    {
        protected BaseService(IUnitOfWork uof) => this.uof = uof;

        protected readonly IUnitOfWork uof;
    }
}
