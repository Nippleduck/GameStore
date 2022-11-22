using GameStore.Application.Models.Genres.DTOs;
using GameStore.Application.Models.Genres.Requests;

namespace GameStore.Application.UnitTests.Services
{
    public class GenreServiceTests : ServiceTestsBase
    {
        public GenreServiceTests()
        {
            sut = new GenreService(uofMock.Object, mapper);
        }

        private readonly IGenreService sut;

        [Theory, AutoData]
        public async Task AddAsync_ShouldPersistNewGenre(AddGenreRequest request)
        {
            var genre = fixture.Build<Genre>()
                .Without(x => x.Id)
                .Without(x => x.ParentGenre)
                .Without(x => x.Subgenres)
                .Without(x => x.Games)
                .With(x => x.Name, request.Name)
                .With(x => x.ParentGenreId, request.ParentGenreId)
                .Create();

            var expected = mapper.Map<GenreDTO>(genre);

            uofMock.Setup(s => s.Genres.AddAsync(It.IsAny<Genre>()));

            var result = await sut.AddAsync(request);

            uofMock.Verify(x => x.Genres.AddAsync(It.IsAny<Genre>()));
            result.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [Theory, RecursionOmitAutoData]
        public async Task GetAllAsync_GenresExists_ShouldReturnGenresCollection
            (IEnumerable<Genre> genres)
        {
            var expected = mapper.Map<IEnumerable<GenreDTO>>(genres);
            uofMock.Setup(s => s.Genres.GetAllAsync().Result).Returns(genres);

            var result = await sut.GetAllAsync();

            result.Should().NotBeNullOrEmpty().And.BeEquivalentTo(expected);
        }

        [Theory, RecursionOmitAutoData]
        public async Task GetByIdAsync_GenreExists_ShouldReturnSearchedGenre(Genre genre)
        {
            var expected = mapper.Map<GenreDTO>(genre);
            uofMock.Setup(s => s.Genres.GetByIdAsync(It.Is<Guid>(x => x == genre.Id)).Result)
                .Returns(genre);

            var result = await sut.GetByIdAsync(genre.Id);

            result.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [Theory, AutoData]
        public async Task GetByIdAsync_GenreDoesNotExist_ShouldThrowNotFoundException(Guid id)
        {
            uofMock.Setup(s => s.Genres.GetByIdAsync(It.IsAny<Guid>()).Result).Returns((Genre?)null);

            var act = async () => await sut.GetByIdAsync(id);

            await act.Should().ThrowExactlyAsync<NotFoundException>();
        }
    }
}
