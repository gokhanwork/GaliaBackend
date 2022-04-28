using FluentValidation;
using Galia.Application.Common.Validators;
using Galia.Application.Storage;
using Galia.Shared.DTOs.Identity;

namespace Galia.Application.Validators.Identity;

public class UpdateProfileRequestValidator : CustomValidator<UpdateProfileRequest>
{
    public UpdateProfileRequestValidator()
    {
        RuleFor(p => p.FirstName).MaximumLength(75).NotEmpty();
        RuleFor(p => p.LastName).MaximumLength(75).NotEmpty();
        RuleFor(p => p.Email).NotEmpty();
        RuleFor(p => p.Image).SetValidator(new FileUploadRequestValidator());
    }
}
