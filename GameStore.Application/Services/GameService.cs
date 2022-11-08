using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Application.Models.Games.DTOs;
using GameStore.Common.Filtering.Filters;
using GameStore.Persistence.UOF;

namespace GameStore.Application.Services
{
    public class GameService : BaseService, IGameService
    {
        public GameService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper) { }

        public async Task<IEnumerable<GameDTO>> GetForSaleAsync(GameFilter filter)
        {
            var games = await uof.Games.GetAllWithFilter(filter);

            if (!games.Any()) return Enumerable.Empty<GameDTO>();

            return mapper.Map<IEnumerable<GameDTO>>(games);
        }
    }
}
