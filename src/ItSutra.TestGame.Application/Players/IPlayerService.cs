using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItSutra.TestGame.Players.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItSutra.TestGame.Players
{
    public interface IPlayerService : IApplicationService
    {
        Task<ListResultDto<PlayerListItem>> GetAllPlayer(GetPlayerInput input);
        Task CreatePlayer(PlayerListItem input);
        Task DeletePlayer(int id);
        Task UpdatePlayer(UpdatePlayerList input);
        Task<PlayerListItem> GetPlayerById(int id);
        Task<ListResultDto<ScoreList>> GetAllScore();
    }
}
