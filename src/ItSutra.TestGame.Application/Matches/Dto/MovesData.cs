using Abp.AutoMapper;
using ItSutra.TestGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItSutra.TestGame.Matches.Dto
{
    [AutoMap(typeof(MatchMove))]
    public class MovesData
    {
        [Required]
        public int MatchId { get; set; }
        [Required]
        public int Location { get; set; }
        [Required]
        public int PlayerId { get; set; }
    }
}
