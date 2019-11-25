using Abp.AutoMapper;
using ItSutra.TestGame.Model;
using System.ComponentModel.DataAnnotations;

namespace ItSutra.TestGame.Matches.Dto
{
    [AutoMap(typeof(Match))]
    public class CreateMatch
    {
        [Required]
        public int FirstPlayerId { get; set; }
        [Required]
        public int SecondPlayerId { get; set; }
    }
}
