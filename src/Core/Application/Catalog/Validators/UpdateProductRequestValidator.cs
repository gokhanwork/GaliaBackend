using FluentValidation;
using Galia.Application.Common.Validators;
using Galia.Application.Storage;
using Galia.Shared.DTOs.Catalog;

namespace Galia.Application.Catalog.Validators;

public class UpdateProductRequestValidator : CustomValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(75).NotEmpty();
        RuleFor(p => p.Rate).GreaterThanOrEqualTo(1).NotEqual(0);
        RuleFor(p => p.Image).SetValidator(new FileUploadRequestValidator());
        RuleFor(p => p.BrandId).NotEmpty().NotNull();
    }
}
