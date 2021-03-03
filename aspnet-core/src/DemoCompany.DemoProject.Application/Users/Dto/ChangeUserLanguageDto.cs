using System.ComponentModel.DataAnnotations;

namespace DemoCompany.DemoProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}