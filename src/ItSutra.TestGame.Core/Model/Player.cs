using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItSutra.TestGame.Model
{
    public class Player : FullAuditedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public int? Win { get; set; }
        public int? Loss { get; set; }
        public int? Ties { get; set; }
        public double? Score { get; set; }
    }
}

