using Abp.AutoMapper;
using ItSutra.TestGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItSutra.TestGame.Matches.Dto
{
    [AutoMap(typeof(Match))]
    public class MatchList
    {
        public TimeSpan Duration { get; set; }
        public int FirstPlayerId { get; set; }
        public int SecondPlayerId { get; set; }
        public int? WinningPlayerId { get; set; }

    }
}
