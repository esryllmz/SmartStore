using FluentValidation;
using SmartStore.Models.Dtos.Categories.Requests;

namespace SmartStore.Services.Validations.Categories
{
    public class UpdateCategoryRequestValidator: AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Category ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name cannot be empty.")
                .MaximumLength(255)
                .WithMessage("Category name cannot exceed 255 characters.")
                .MinimumLength(2)
                .WithMessage("Category name must be at least 2 characters long.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("Category name must contain only letters and spaces.");
        }
    }
}
