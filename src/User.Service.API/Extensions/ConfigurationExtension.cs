using User.Service.API.Exceptions;

namespace User.Service.API.Extensions
{
	/// <summary>
	/// Методы расширения для извлечения конфигураций
	/// </summary>
	public static class ConfigurationExtension
	{
		/// <summary>
		/// Получение строки подключения из конфигов сервиса
		/// </summary>
		/// <param name="configs"><see cref="ConfigurationManager"/></param>
		/// <param name="sectionName">ключ секции с настройками подключения к БД</param>
		/// <returns>строка подключения к БД</returns>
		/// <exception cref="Exception"></exception>
		private static string GetConnectionString(this ConfigurationManager configs, string sectionName)
		{
			var connectionString = configs.GetSection("ConnectionStrings").GetSection(sectionName).Get<string>();
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new Exception("Не найдена секция подключения к БД");
			}

			return connectionString;
		}
	}
}
