using MediatR;

namespace User.Service.Application.V10.Registration.Commands
{
	/// <summary>
	/// Комманда регистрации пользователя
	/// </summary>
	public class SignUpCommand : IRequest<Unit>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SignUpCommand"/> class.
		/// </summary>
		/// <param name="email"><inheritdoc cref="Email" path="/summary"/></param>
		/// <param name="password"><inheritdoc cref="Password" path="/summary"/></param>
		public SignUpCommand(
			string email,
			string password)
		{
			this.Email = email;
			this.Password = password;
		}

		/// <summary>
		/// Электронная почта
		/// </summary>
		public string Email { get; }

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; }
	}
}
