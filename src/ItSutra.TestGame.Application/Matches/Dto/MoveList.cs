using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItSutra.TestGame.Matches.Dto
{
    public class MoveList
    {
        [Required]
        public int MatchId { get; set; }
    }
}
