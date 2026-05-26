using FluentValidation;
using Books.Models.DTOs;

namespace Books.Validator
{
    public class BookCreateDTOValidator : AbstractValidator<BookCreateDTO>
    {
        public BookCreateDTOValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Pages)
                .GreaterThan(0)
                .LessThanOrEqualTo(5000);

            RuleFor(x => x.ImgUrl)
                .NotEmpty()
                .Must(BeAValidUrl)
                .WithMessage("Img must be a valid URL");
        }
        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
