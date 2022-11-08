using GameStore.Application.Models.Games.DTOs;
using GameStore.Common.Filtering.Filters;

namespace GameStore.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetForSaleAsync(GameFilter filter);
    }
}
