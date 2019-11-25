using Abp.AutoMapper;
using ItSutra.TestGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static ItSutra.TestGame.Model.Match;

namespace ItSutra.TestGame.Matches.Dto
{
    [AutoMap(typeof(Match))]
    public class EndMatch
    {
        [Required]
        public int WinningPlayerId { get; set; }
        [Required]
        public int MatchId { get; set; }
    }
}
