using FluentValidation;
using Galia.Application.Common.Validators;
using Galia.Shared.DTOs.Catalog;

namespace Galia.Application.Catalog.Validators;

public class CreateBrandRequestValidator : CustomValidator<CreateBrandRequest>
{
    public CreateBrandRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(75).NotEmpty();
    }
}
