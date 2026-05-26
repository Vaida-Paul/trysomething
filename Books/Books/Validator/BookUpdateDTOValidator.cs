using Books.Models.DTOs;
using FluentValidation;

namespace Books.Validator
{
    public class BookUpdateDTOValidator : AbstractValidator<BookUpdateDTO>
    {
        public BookUpdateDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Pages)
                .GreaterThan(0)
                .LessThanOrEqualTo(5000);
        }
    }
}
