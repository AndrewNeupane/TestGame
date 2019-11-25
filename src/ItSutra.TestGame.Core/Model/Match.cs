using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItSutra.TestGame.Model
{
    public class Match : FullAuditedEntity
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public MatchState State { get; set; }
        public int FirstPlayerId { get; set; }
        public int SecondPlayerId { get; set; }
        public int? WinningPlayerId { get; set; }

        public virtual Player FirstPlayer { get; set; }

        public virtual Player SecondPlayer { get; set; }

        public virtual Player WinningPlayer { get; set; }

        public virtual ICollection<MatchMove> MatchMoves { get; set; }

        public Match()
        {
            if (State == MatchState.Open)
                StartTime = DateTime.Now;
            if (State == MatchState.Completed)
                EndTime = DateTime.Now;
            Duration = (EndTime - StartTime);
            MatchMoves = new List<MatchMove>();
        }
        public enum MatchState : byte
        {
            Open = 1,
            Completed = 0
        }
    }
}
