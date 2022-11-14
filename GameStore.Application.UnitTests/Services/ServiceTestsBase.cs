using AutoFixture;
using AutoMapper;
using Moq;
using GameStore.Application.Services;
using GameStore.Persistence.UOF;

namespace GameStore.Application.UnitTests.Services
{
    public class ServiceTestsBase
    {
        public ServiceTestsBase()
        {
            var configuration = new MapperConfiguration(config => config.AddMaps(typeof(BaseService).Assembly));
            mapper = new Mapper(configuration);

            uofMock = new();
            fixture = new();
        }

        protected readonly IMapper mapper;
        protected readonly Mock<IUnitOfWork> uofMock;
        protected readonly Fixture fixture;
    }
}
