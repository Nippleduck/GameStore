using GameStore.Application.Models.Games.Requests;
using GameStore.Application.Models.Games.DTOs;
using GameStore.Common.Filtering.Models;

namespace GameStore.Application.UnitTests.Services
{
    public class GameServiceTests : ServiceTestsBase
    {
        public GameServiceTests()
        {
            mediaStorageMock = new Mock<IExternalMediaStorage>();
            sut = new GameService(uofMock.Object, mapper, mediaStorageMock.Object);
        }

        private readonly Mock<IExternalMediaStorage> mediaStorageMock;
        private readonly IGameService sut;

        [Theory, RecursionOmitAutoData]
        public async Task GetByIdAsync_GameExists_ShouldReturnGameDTO(Guid id, Game game)
        {
            var mapped = mapper.Map<GameDTO>(game);
            uofMock.Setup(s => s.Games.GetByIdWithDetailsAsync(id).Result).Returns(game);

            var result = await sut.GetByIdAsync(id);

            result.Should().NotBeNull().And.BeEquivalentTo(mapped);
        }

        [Theory, AutoData]
        public async Task GetByIdAsync_GameDoesNotExist_ShouldThrowNotFoundException(Guid id)
        {
            uofMock.Setup(s => s.Games.GetByIdWithDetailsAsync(id).Result).Returns((Game?)null);

            var act = async () => await sut.GetByIdAsync(id);

            await act.Should().ThrowExactlyAsync<NotFoundException>();
        }

        [Theory, RecursionOmitAutoData]
        public async Task GetForSaleAsync_GamesExist_ShouldReturnGamesDTOsCollection
            (GameFilter filter, IEnumerable<Game> games)
        {
            uofMock.Setup(s => s.Games.GetAllWithFilterAsync(It.IsAny<GameFilter>()).Result)
                .Returns(games);
            var mapped = mapper.Map<IEnumerable<GameDTO>>(games);

            var result = await sut.GetForSaleAsync(filter);

            result.Should().NotBeNullOrEmpty().And.BeEquivalentTo(mapped);
        }

        [Theory, AutoData]
        public async Task DeleteByIdAsync_GameExist_ShoudSuccessfullyDeleteGame(Guid id)
        {
            uofMock.Setup(s => s.Games.DeleteByIdAsync(It.IsAny<Guid>()).Result).Returns(true);

            var act = async () => await sut.DeleteByIdAsync(id);

            await act.Should().NotThrowAsync<NotFoundException>();
        }

        [Theory, AutoData]
        public async Task DeleteByIdAsync_GameDoesNotExist_ShouldThrowNotFoundException(Guid id)
        {
            uofMock.Setup(s => s.Games.DeleteByIdAsync(It.IsAny<Guid>()).Result).Returns(false);

            var act = async () => await sut.DeleteByIdAsync(id);
            
            await act.Should().ThrowExactlyAsync<NotFoundException>();
        }

        [Theory, RecursionOmitAutoData]
        public async Task AddAsync_ShouldPersistNewGame(ICollection<Genre> genres)
        {
            var game = fixture.Build<Game>()
                .Without(x => x.Id)
                .With(x => x.Genres, genres)
                .Create();

            var expected = mapper.Map<GameDTO>(game);

            var request = fixture.Build<SetGameDetailsRequest>()
                .With(x => x.Name, game.Name)
                .With(x => x.Description, game.Description)
                .With(x => x.GenreIds, genres.Select(g => g.Id).ToArray())
                .With(x => x.Price, game.Price)
                .Create();

            uofMock.Setup(s => s.Games.AddAsync(It.IsAny<Game>()));
            uofMock.Setup(s => s.Genres.GetByIdAsync(It.IsAny<Guid>()).Result)
                .Returns<Guid>(x => genres.First(g => g.Id == x));

            var result = await sut.AddAsync(request);

            result.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [Theory, RecursionOmitAutoData]
        public async Task AddAsync_GenreDoesNotExist_ShouldThrowNotFoundException
            (SetGameDetailsRequest request)
        {
            uofMock.Setup(s => s.Genres.GetByIdAsync(It.IsAny<Guid>()).Result)
                .Returns((Genre?)null);

            var act = async () => await sut.AddAsync(request);

            await act.Should().ThrowExactlyAsync<NotFoundException>();
        }

        [Theory, RecursionOmitAutoData]
        public async Task UpdateAsync_ShouldPersistChanges
            (ICollection<Genre> genres, Game game)
        {
            var request = fixture.Build<SetGameDetailsRequest>()
                .With(x => x.GenreIds, genres.Select(g => g.Id).ToArray())
                .Create();

            var expected = mapper.Map(request, game);
            expected.Genres = genres;

            uofMock.Setup(s => s.Genres.GetByIdAsync(It.IsAny<Guid>()).Result)
                .Returns<Guid>(x => genres.First(g => g.Id == x));
            uofMock.Setup(s => s.Games.GetByIdWithDetailsAsync(It.Is<Guid>(x => x.Equals(game.Id))).Result)
                .Returns(game);
            uofMock.Setup(s => s.Games.Update(It.Is<Game>(x => x.Id == game.Id)));

            await sut.UpdateAsync(game.Id, request);

            uofMock.Verify(x => x.Games.Update(expected));
        }

        [Theory, AutoData]
        public async Task UpdateAsync_GameDoesNotExist_ShouldThrowNotFoundException
            (Guid id, SetGameDetailsRequest request)
        {
            uofMock.Setup(s => s.Games.GetByIdWithDetailsAsync(It.IsAny<Guid>()).Result)
                .Returns((Game?)null);

            var act = async () => await sut.UpdateAsync(id, request);

            await act.Should().ThrowExactlyAsync<NotFoundException>();
        }
    }
}
