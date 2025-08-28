using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebApi.Models.DTO
{
    public class SetUpPasswordDto
    {
        [EmailAddress]
        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
