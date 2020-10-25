using Blog.Mapper.ViewModels.PostViewModels;
using FluentValidation;

namespace Blog.Validations.PostValidation
{
    public class CreateValidator : AbstractValidator<PostCreateVM>
    {
        public CreateValidator()
        {
            RuleFor(rule => rule.Title).NotEmpty().WithMessage("Title alanı zorunlu alandır");
            RuleFor(rule => rule.Content).NotEmpty().WithMessage("Content alanı zorunlu alandır");
            RuleFor(rule => rule.PublishDate).NotEmpty().WithMessage("PublishDate alanı zorunlu alandır");
        }
    }
}