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
				.NotNull()
				.NotEmpty()
				.WithMessage("Пароль обязательный параметр");
		}
	}
}
