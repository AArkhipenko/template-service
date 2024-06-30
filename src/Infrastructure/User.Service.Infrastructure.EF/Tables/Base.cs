namespace User.Service.Infrastructure.EF.Tables
{
	/// <summary>
	/// Модель таблицы public.base
	/// </summary>
	internal class Base
	{
		/// <summary>
		/// ИД записи
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД категории словаря
		/// </summary>
		public int IdCategory { get; set; }

		/// <summary>
		/// Код записи
		/// </summary>
		public string Code { get; set; } = string.Empty;

		/// <summary>
		/// Наименование записи
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Дата создания записи
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Дата изменения записи
		/// </summary>
		public DateTime Edited { get; set; }
	}
}
