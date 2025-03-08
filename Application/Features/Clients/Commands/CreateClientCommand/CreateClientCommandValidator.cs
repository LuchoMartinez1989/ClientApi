using FluentValidation;

namespace Application.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommandValidator:AbstractValidator<CreateClientCommand>
    {

        public CreateClientCommandValidator()
        {
            RuleFor(c => c.IdenticacionCode).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(15).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Name).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Lastnames).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Mail).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(30).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters").Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("property:{PropertName} must be a valid E-mail");
            RuleFor(c => c.IdTypeIdentification).NotNull().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.Address).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.BornDate).NotNull().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.Phone).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(15).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Gender).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(30).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
        }
    }
}
