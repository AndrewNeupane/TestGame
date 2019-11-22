using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using ItSutra.TestGame.Matches.Dto;
using ItSutra.TestGame.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ItSutra.TestGame.Matches
{
    public class MatchService : TestGameAppServiceBase, IMatchService
    {
        private readonly IRepository<Match> _matchRepository;

        public MatchService(IRepository<Match> matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task CreateMatch(CreateMatch input)
        {
            await _matchRepository.InsertAsync(ObjectMapper.Map<Match>(input));
        }

        public async Task CreateMove(MovesData input)
        {
            var match = await _matchRepository.GetAsync(input.MatchId);
            if (input.PlayerId != match.FirstPlayerId && input.PlayerId != match.SecondPlayerId)
                throw new AbpValidationException();
            if(input.Location >= 9)
                throw new AbpValidationException();
/*            if(input.Location == match.MatchMoves)
                throw new AbpValidationException();*/
            match.MatchMoves.Add(new MatchMove { PlayerId = input.PlayerId, Location = input.Location });
        }

        public async Task EndMatch(EndMatch input)
        {
            var match = await _matchRepository.GetAsync(input.MatchId);
            match.State = input.State;
            if (input.WinningPlayerId == match.FirstPlayerId)
            {
                match.FirstPlayer.Win = Convert.ToInt32(match.FirstPlayer.Win) + 1;
                match.FirstPlayer.Score = Convert.ToInt32(match.FirstPlayer.Score) + 1;
                match.SecondPlayer.Loss = Convert.ToInt32(match.SecondPlayer.Loss) + 1;
                match.WinningPlayerId = match.FirstPlayerId;
            }
            if (input.WinningPlayerId == match.SecondPlayerId)
            {
                match.SecondPlayer.Win = Convert.ToInt32(match.SecondPlayer.Win) + 1;
                match.SecondPlayer.Score = Convert.ToInt32(match.SecondPlayer.Score)+ 1;
                match.FirstPlayer.Loss = Convert.ToInt32(match.FirstPlayer.Loss) + 1;
                match.WinningPlayerId = match.SecondPlayerId;
            }
            if (input.WinningPlayerId == 0)
            {
                match.FirstPlayer.Ties = Convert.ToInt32(match.FirstPlayer.Ties) + 1;
                match.FirstPlayer.Score = Convert.ToInt32(match.FirstPlayer.Score) + 0.5;
                match.SecondPlayer.Ties = Convert.ToInt32(match.SecondPlayer.Ties) + 1;
                match.SecondPlayer.Score = Convert.ToInt32(match.SecondPlayer.Score) + 0.5;
            }
        }

        public async Task<MatchList> GetMatchById(int id) => ObjectMapper.Map<MatchList>(await _matchRepository.GetAsync(id));

        public async Task<ListResultDto<MatchList>> GetMatchList()
        {
            var matchLists = await _matchRepository
               .GetAll()
               .ToListAsync();
            return new ListResultDto<MatchList>(ObjectMapper.Map<List<MatchList>>(matchLists));
        }

        public async Task<ListResultDto<MovesData>> GetMovesByMatchId(MoveList input)
        {
            var match = await _matchRepository.GetAsync(input.MatchId);
            return new ListResultDto<MovesData>(ObjectMapper.Map<List<MovesData>>(match.MatchMoves));
        }
    }
}
