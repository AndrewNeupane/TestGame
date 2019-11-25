using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItSutra.TestGame.Matches.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItSutra.TestGame.Matches
{
    public interface IMatchService : IApplicationService
    {
        Task<int> CreateMatch(CreateMatch input);
        Task EndMatch(EndMatch input);
        Task<ListResultDto<MatchList>> GetMatchList();
        Task<MatchList> GetMatchById(int id);
        Task CreateMove(MovesData input);
        Task<ListResultDto<MovesData>> GetMovesByMatchId(MoveList input);
    }
}
