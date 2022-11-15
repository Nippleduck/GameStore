namespace GameStore.Application.Services
{
    public abstract class BaseService
    {
        protected BaseService(IUnitOfWork uof, IMapper mapper)
        {
            this.uof = uof;
            this.mapper = mapper;
        }

        protected readonly IUnitOfWork uof;
        protected readonly IMapper mapper;
    }
}
