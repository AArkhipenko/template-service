namespace User.Service.Infrastructure.EF.Tables
{
	/// <summary>
	/// Модель таблицы general.user
	/// </summary>
	internal class User: Base
	{
		/// <summary>
		/// Электронная почта
		/// </summary>
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; } = string.Empty;
	}
}
