using Abp.AutoMapper;
using ItSutra.TestGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItSutra.TestGame.Players.Dto
{
    [AutoMap(typeof(Player))]
    public class PlayerData
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
