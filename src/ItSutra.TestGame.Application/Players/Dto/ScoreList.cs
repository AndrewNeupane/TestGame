using Abp.AutoMapper;
using ItSutra.TestGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItSutra.TestGame.Players.Dto
{
    [AutoMap(typeof(Player))]
    public class ScoreList
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Win { get; set; }
        public int? Loss { get; set; }
        public int? Ties { get; set; }
        public double? Score { get; set; }
    }
}
