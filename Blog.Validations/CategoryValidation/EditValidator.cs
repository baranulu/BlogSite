using Blog.Mapper.ViewModels.CategoryViewModels;
using FluentValidation;

namespace Blog.Validations.CategoryValidation
{
    public class EditValidator : AbstractValidator<CategoryEditVM>
    {
        public EditValidator()
        {
            RuleFor(rule => rule.Id).NotEmpty().WithMessage("Id parametresi zorunlu alandır");
            RuleFor(rule => rule.CategoryName).NotEmpty().WithMessage("Kategori adı zorunlu alandır");
        }
    }
}
