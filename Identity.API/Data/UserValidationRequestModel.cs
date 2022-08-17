using System.ComponentModel.DataAnnotations;

namespace Identity.API.Data
{
    public record UserValidationRequestModel([Required][EmailAddress] string UserName, [Required] string Password);
}
