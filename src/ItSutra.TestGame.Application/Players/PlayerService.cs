using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using ItSutra.TestGame.Model;
using ItSutra.TestGame.Players.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using System.Globalization;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;

namespace ItSutra.TestGame.Players
{
    public class PlayerService : TestGameAppServiceBase, IPlayerService
    {
        private readonly IRepository<Player> _playerRepository;


        public PlayerService(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task CreatePlayer(PlayerListItem input)
        {
            if (await _playerRepository.GetAll().AnyAsync(x => x.Email == input.Email))
                throw new AbpValidationException("Validation Error", new List<ValidationResult> { new ValidationResult("User already exists") });
            if (Convert.ToInt32(DateTime.Today.Year - input.DateOfBirth.Year) <= 18)
                throw new AbpValidationException();

            await _playerRepository.InsertAsync(ObjectMapper.Map<Player>(input));
        }

        public async Task DeletePlayer(int id) => await _playerRepository.DeleteAsync(id);

        public async Task<ListResultDto<PlayerListItem>> GetAllPlayer(GetPlayerInput input)
        {
            var playerLists = await _playerRepository
               .GetAll()
               .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    s => s.FirstName.Contains(input.Filter) ||
                         s.LastName.Contains(input.Filter) ||
                         s.Email.Contains(input.Filter) ||
                         s.PhoneNumber.ToString().Contains(input.Filter)
                )
               .OrderBy(o => o.CreationTime)
               .ToListAsync();

            return new ListResultDto<PlayerListItem>(ObjectMapper.Map<List<PlayerListItem>>(playerLists));
        }

        public async Task<ListResultDto<ScoreList>> GetAllScore()
        {
            var scoreList = await _playerRepository
                .GetAll()
                .Select(
                    s => new ScoreList
                    {
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Win = s.Win,
                        Loss = s.Loss,
                        Ties = s.Ties,
                        Score = s.Score
                    }
                )
                .OrderByDescending(p => p.Score)
                .ToListAsync();
            return new ListResultDto<ScoreList>(ObjectMapper.Map<List<ScoreList>>(scoreList));
        }

        public async Task<PlayerListItem> GetPlayerById(int id) => ObjectMapper.Map<PlayerListItem>(await _playerRepository.GetAsync(id));
        public async Task UpdatePlayer(UpdatePlayerList input)
        {
            var updatePlayer = await _playerRepository.GetAsync(input.Id);
            updatePlayer.FirstName = input.FirstName;
            updatePlayer.LastName = input.LastName;
            updatePlayer.PhoneNumber = input.PhoneNumber;
            updatePlayer.Email = input.Email;
            updatePlayer.DateOfBirth = input.DateOfBirth.ToString("MM/DD/YYY", CultureInfo.InvariantCulture);

        }
    }
}
