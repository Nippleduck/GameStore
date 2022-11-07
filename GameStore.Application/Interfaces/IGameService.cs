using GameStore.Application.Models.Games.DTOs;

namespace GameStore.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetForSaleAsync();
    }
}
