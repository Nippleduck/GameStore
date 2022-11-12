using GameStore.Application.Models.Games.DTOs;
using GameStore.Application.Models.Games.Requests;
using GameStore.Common.Filtering.Models;

namespace GameStore.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetForSaleAsync(GameFilter filter);
        Task<GameDTO> GetByIdAsync(Guid id);
        Task<GameDTO> AddAsync(SetGameDetailsRequest request);
        Task UpdateAsync(Guid id, SetGameDetailsRequest request);
        Task DeleteByIdAsync(Guid id);
    }
}
