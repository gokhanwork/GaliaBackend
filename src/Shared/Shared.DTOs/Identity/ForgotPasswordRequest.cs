using System.ComponentModel.DataAnnotations;

namespace Galia.Shared.DTOs.Identity;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
