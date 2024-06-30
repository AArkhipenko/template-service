namespace User.Service.Application.V10.Registration.DTO
{
	/// <summary>
	/// Параметры запроса на регистрацию пользователя
	/// </summary>
	public class SignUpRequestDTO
	{
		/// <summary>
		/// Электроная почта
		/// </summary>
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; } = string.Empty;
	}
}
