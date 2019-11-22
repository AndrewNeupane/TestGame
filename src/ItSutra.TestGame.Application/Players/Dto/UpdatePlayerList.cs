using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItSutra.TestGame.Players.Dto
{
    public class UpdatePlayerList : EntityDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
