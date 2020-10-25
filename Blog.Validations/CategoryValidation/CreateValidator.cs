namespace Blog.Validations.CategoryValidation
{
    using Blog.Mapper.ViewModels.CategoryViewModels;
    using FluentValidation;

    public class CreateValidator : AbstractValidator<CategoryCreateVM>
    {
        public CreateValidator()
        {
            RuleFor(rule => rule.CategoryName).NotEmpty().WithMessage("Kategori adı zorunlu alandır");
        }
    }
}
