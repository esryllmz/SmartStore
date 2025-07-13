using FluentValidation;
using SmartStore.Models.Dtos.Categories.Requests;

namespace SmartStore.Services.Validations.Categories
{
    public class CreateCategoryRequestValidator: AbstractValidator<CreateCategoryRequest>
    {

        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .MaximumLength(255)
                .WithMessage("Category name must not exceed 255 characters.")
                .MinimumLength(2)
                .WithMessage("Category name must be at least 2 characters long.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("Category name must contain only letters and spaces.");


        }

    }
}
