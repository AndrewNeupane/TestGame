using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Abp.Threading;
using ItSutra.TestGame.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItSutra.TestGame.Players.Dto
{
    [AutoMap(typeof(Player))]
    public class PlayerListItem  
        //Inherit ICustomValidate
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

        /*public void AddValidationErrors(CustomValidationContext context)
        {
            var playerRepository = context.IocResolver.Resolve<IRepository<Player>>();
            AsyncHelper.RunSync(async () =>
            {
                if (await playerRepository.GetAll().AnyAsync(x => x.Email == Email))
                {
                    context.Results.Add(new ValidationResult("User already exists"));
                }

            });
        }*/ 
    }
}
