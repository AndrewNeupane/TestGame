using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItSutra.TestGame.Model
{
    public class MatchMove : FullAuditedEntity
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int Location { get; set; }
    }
}
