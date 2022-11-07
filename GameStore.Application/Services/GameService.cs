using GameStore.Application.Interfaces;
using GameStore.Application.Models.Games.DTOs;
using GameStore.Persistence.UOF;

namespace GameStore.Application.Services
{
    public class GameService : BaseService, IGameService
    {
        public GameService(IUnitOfWork uof) : base(uof) { }

        public Task<IEnumerable<GameDTO>> GetForSaleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
