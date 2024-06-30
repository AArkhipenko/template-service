using FluentValidation;
using MediatR;
using System.Text.RegularExpressions;
using User.Service.Application.V10.Registration.DTO;

namespace User.Service.Application.V10.Registration.Validators
{
	/// <summary>
	/// Валидатор параметров запрос регистрации пользователя
	/// </summary>
	public class SignUpRequestValidator : AbstractValidator<SignUpRequestDTO>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SignUpRequestValidator"/> class.
		/// </summary>
		public SignUpRequestValidator()
		{
			RuleFor(request => request.Email)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull()
				.NotEmpty()
				.WithMessage("Электронная почта обязательный параметр")
				.Must(email =>
				{
					Regex regex = new Regex(@"^.*@.*\..*$");
					return regex.IsMatch(email);
				})
				.WithMessage("Электронная почта должна соответствовать шаблону example@example.example");

			RuleFor(request => request.Password)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull()
				.NotEmpty()
				.WithMessage("Пароль обязательный параметр")
				.Must(x => x.Count() >= 8)
				.WithMessage("Пароль должен содержать не менее 8 символов");
		}
	}
}
