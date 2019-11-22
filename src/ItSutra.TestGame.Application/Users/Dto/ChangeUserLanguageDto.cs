using System.ComponentModel.DataAnnotations;

namespace ItSutra.TestGame.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}